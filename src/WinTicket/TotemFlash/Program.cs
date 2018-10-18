using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Musei.Module;

namespace TotemFlash
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CreateSessions();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static Session[] Sessions { get; set; }

        public static bool VerifySession(int pos)
        {
            try
            {
                var ses = Sessions[pos];

                if (ses.IsConnected)
                {
                    var x = ses.GetObjectByKey<Postazione>(new Guid("a5f47913-348c-e011-944d-111fc6f3d78c"));
                    if (x != null) return true;
                }
            }
            catch (Exception)
            {
                
            }

            return false;
        }

        public static void CreateSessions()
        {
            // generazione sequenziale dei GUID
            XpoDefault.GuidGenerationMode = GuidGenerationMode.UuidCreateSequential;

            //IDataStore store = XpoDefault.GetConnectionProvider("", AutoCreateOption.None);

            //XpoDefault.DataLayer = new SimpleDataLayer(store);

            XpoDefault.DataLayer = null;
            XpoDefault.Session = null;

            var sex = new Session[2];

            IDataStore store1 = XpoDefault.GetConnectionProvider(MSSqlConnectionProvider.GetConnectionString(
                "192.168.0.20", "sa", "xxx", "MuseiXafRev1locale"), AutoCreateOption.None);

            IDataStore store2 = XpoDefault.GetConnectionProvider(MSSqlConnectionProvider.GetConnectionString(
                "192.168.0.30", "sa", "xxx", "MuseiXafRev1locale"), AutoCreateOption.None);

            sex[0] = new Session(new SimpleDataLayer(store1));
            sex[1] = new Session(new SimpleDataLayer(store2));

            Sessions = sex;
        }
    }
}
