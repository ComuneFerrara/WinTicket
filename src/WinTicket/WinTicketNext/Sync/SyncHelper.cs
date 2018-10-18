using System;
using Musei.Module;
using DevExpress.Xpo;
using System.Threading;

namespace WinTicketNext.Sync
{
    public class SyncHelper
    {
        public void GoSync()
        {
            using (Session session = new Session())
            {
                if (StaticInfo.NoSync() || session.DataLayer.Connection == null || !session.DataLayer.Connection.ConnectionString.Contains("MuseiXafRev1locale"))
                {
                    Result = true;
                    SyncFinished = true;

                    try
                    {
                        Postazione postazione = session.GetObjectByKey<Postazione>(Program.Postazione.Oid);
                        postazione.SyncTry = DateTime.Now;
                        postazione.SyncSuccess = DateTime.Now;
                        postazione.Save();
                    }
                    catch (Exception)
                    {
                        // possiamo avere un problema sullo schema del database
                        // ignoriamo e proseguiamo l'operazione ..                    
                    }
                }
                else
                {
                    try
                    {
                        Postazione postazione = session.GetObjectByKey<Postazione>(Program.Postazione.Oid);
                        postazione.SyncTry = DateTime.Now;
                        postazione.Save();
                    }
                    catch (Exception)
                    {
                        // possiamo avere un problema sullo schema del database
                        // ignoriamo e proseguiamo l'operazione ..                    
                    }

                    Thread newt = new Thread(start);
                    newt.Start(this);
                }
            }
        }

        private void start(object parametro)
        {
            SyncHelper mestesso = parametro as SyncHelper;

            ResultInfo = new MergeSyncLib.ReplicamenteInfo();

            try
            {
                MergeSyncLib.Replicamente rx = new MergeSyncLib.Replicamente(ResultInfo);

                mestesso.Result = rx.Go("(local)\\SQLEXPRESS", "MuseiXafRev1locale");
            }
            catch (Exception ex)
            {
                mestesso.Result = false;
                mestesso.ResultInfo.Info += Environment.NewLine + ex.Message;
            }

            mestesso.SyncFinished = true;
        }

        public bool SyncFinished { get; set; }
        public bool ResultProcessed { get; set; }
        public bool Result { get; set; }
        public MergeSyncLib.ReplicamenteInfo ResultInfo { get; set; }
        
        public void End()
        {
            ResultProcessed = true;

            using (Session session = new Session())
            {
                try
                {
                    Postazione postazione = session.GetObjectByKey<Postazione>(Program.Postazione.Oid);
                    if (Result)
                    {
                        postazione.SyncResult = EnumSyncResult.Ok;
                        postazione.SyncSuccess = postazione.SyncTry;
                        postazione.Save();
                    }
                    else
                    {
                        postazione.SyncResult = EnumSyncResult.Error;
                        postazione.Save();
                    }
                }
                catch (Exception)
                {
                    // possiamo avere un problema sullo schema del database
                    // ignoriamo e proseguiamo l'operazione ..                                        
                }

                try
                {
                    Messaggio msg = new Messaggio(session);
                    msg.Data = DateTime.Now;

                    if (Result)
                    {
                        //msg.Oggetto = String.Format("SYNCOK {0}: {1} sec. Conflitti ({2}/{3}) Modifiche ({4}/{5})", Environment.MachineName,
                        //    ResultInfo.Durata(),
                        //    ResultInfo.ConflittiSub, ResultInfo.ConflittiPub, ResultInfo.ModificheSub, ResultInfo.ModifichePub);
                        //msg.TestoEsteso = ResultInfo.Info;
                        //msg.Autore = session.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                        //msg.Tipologia = EnumTipoMessaggio.Normale;
                        //msg.Save();
                    }
                    else
                    {
                        msg.Oggetto = "SYNC_ERR: " + Environment.MachineName;
                        msg.TestoEsteso = ResultInfo.Info;
                        msg.Autore = session.GetObjectByKey<Utente>(Program.UtenteCollegato.Oid);
                        msg.Tipologia = EnumTipoMessaggio.SyncError;
                        msg.Save();
                    }
                }
                catch (Exception)
                {
                    // possiamo avere un problema sullo schema del database
                    // ignoriamo e proseguiamo l'operazione ..                                        
                }
            }
        }
    }
}
