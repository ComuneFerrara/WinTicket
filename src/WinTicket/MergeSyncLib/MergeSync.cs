using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Replication;
using Microsoft.SqlServer.Management.Common;
using System.IO;

namespace MergeSyncLib
{
    public class Replicamente
    {
        //public delegate void Log(string text);

        //private Log m_WriteLine;

        public ReplicamenteInfo Info;

        public Replicamente(ReplicamenteInfo info)
        {
            Info = info;

            Info.DateStart = DateTime.Now;
            Log(string.Format("Merge process started at: {0}", Info.DateStart));
        }

        public bool Go(string serverName, string dbname)
        {
            bool result = true;

            ServerConnection subscriberConn = new ServerConnection(serverName);

            try
            {
                // Connect to the Subscriber.
                subscriberConn.Connect();

                ReplicationServer replserv = new ReplicationServer(subscriberConn);

                foreach (SubscriberSubscription subscription in replserv.EnumSubscriberSubscriptions(dbname, 2))
                {
                    if (!string.IsNullOrEmpty(dbname))
                        if (dbname != subscription.SubscriptionDBName)
                            continue;

                    if (!SynchronizeSubscription(subscription, serverName))
                        result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
                Log(ex.Message);
            }
            finally
            {
                subscriberConn.Disconnect();
            }

            Info.DateEnd = DateTime.Now;
            Log(string.Format("Merge process ended at: {0}", Info.DateEnd));

            return result;
        }

        private bool SynchronizeSubscription(SubscriberSubscription subscriptionparameters, string serverName)
        {
            bool result = true;
            ServerConnection conn = null;

            try
            {
                conn = new ServerConnection(serverName);
                // Connect to the Subscriber.
                conn.Connect();

                if (!conn.IsOpen) return false;

                // Define the pull subscription.
                MergePullSubscription subscription = new MergePullSubscription();
                subscription.ConnectionContext = conn;
                subscription.DatabaseName = subscriptionparameters.SubscriptionDBName;
                subscription.PublisherName = subscriptionparameters.PublisherName;
                subscription.PublicationDBName = subscriptionparameters.PublicationDBName;
                subscription.PublicationName = subscriptionparameters.PublicationName;

                // If the pull subscription exists, then start the synchronization.
                if (subscription.LoadProperties())
                {
                    // Get the agent for the subscription.
                    MergeSynchronizationAgent agent = subscription.SynchronizationAgent;

                    agent.UseInteractiveResolver = true;
                    agent.InternetTimeout = 600;
                    //if (File.Exists(@"c:\DotNet\tosi2010-09-01.zip"))
                    //{
                    //    DateTime dt = DateTime.Now;
                    //    agent.Output =
                    //        string.Format(@"c:\DotNet\out_{0}_{1}_{2}_{3}_{4}.txt", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute);
                    //    agent.OutputVerboseLevel = 2;
                    //}

                    // Synchronously start the Merge Agent for the subscription.
                    agent.Status += OnAgentStatusEventHandler;
                    agent.Synchronize();

                    Info.ConflittiPub = agent.PublisherConflicts;
                    Info.ConflittiSub = agent.SubscriberConflicts;
                    Info.ModificheSub = agent.SubscriberChanges;
                    Info.ModifichePub = agent.PublisherChanges;

                    if (agent.PublisherConflicts > 0 || agent.SubscriberConflicts > 0)
                    {
                        Log("**************************************");
                        Log(string.Format("Conflitti: pub: {0}, sub: {1}",
                            agent.PublisherConflicts,
                            agent.SubscriberConflicts
                            ));
                    }
                }
                else
                {
                    // Do something here if the pull subscription does not exist.
                    throw new ApplicationException(String.Format(
                        "La sottoscrizione '{0}' non esiste sul server {1}",
                        subscriptionparameters.PublicationName, conn.ServerInstance));
                }
            }
            catch (ComErrorException comErrorEx)
            {
                result = false;
                throw new ApplicationException(
                    "Impossibile connettersi al server di pubblicazione, " +
                    "verificare la connessione di rete e che la sottoscrizione " +
                    "sia stata creata correttamnte.", comErrorEx);
            }
            catch (Exception ex)
            {
                result = false;
                // Implement appropriate error handling here.
                throw new ApplicationException("The subscription could not be " +
                    "synchronized. Verify that the subscription has " +
                    "been defined correctly.", ex);
            }
            finally
            {
                if (conn != null)
                    conn.Disconnect();
            }

            Info.Result = result;
            return result;
        }

        private void OnAgentStatusEventHandler(object sender, StatusEventArgs e)
        {
            string messaggio = string.Format("{0}: Agent:{1}({2}): {3}", DateTime.Now, e.MessageStatus, e.PercentCompleted, e.Message);
            Info.Info += messaggio + Environment.NewLine;
        }

        private void Log(string text)
        {
            string messaggio = string.Format("{0}: LOG: {1}", DateTime.Now, text);
            Info.Info += messaggio + Environment.NewLine;
        }
    }

}
