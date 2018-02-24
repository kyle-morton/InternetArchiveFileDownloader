using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveDownloader
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                var archiveFiles = LoadJson();

                foreach(var file in archiveFiles.Files) {
                    Download(file);
                }

                Console.WriteLine("Terminating...");
            }
            catch(Exception ex) {
                Console.WriteLine("Exception: " + ex);

                //restart app
                var info = new ProcessStartInfo(Environment.GetCommandLineArgs()[0]);
                Process.Start(info);
            }
            Console.ReadKey ();
        }

        #region JSON

        private static ArchiveFiles LoadJson()
        {
            ArchiveFiles container;
            using (StreamReader r = new StreamReader("JS\\source-links.json"))
            {
                string json = r.ReadToEnd();
                //Console.ReadKey();
                container = JsonConvert.DeserializeObject<ArchiveFiles>(json);
            }
            return container;
        }

        #endregion

        #region DOWNLOAD FILE

        private static void Download(ArchiveFile file)
        {
            var dest = ConfigurationManager.AppSettings["Destination"];
            var finalDestination = $"{dest}{file.Name}";
            Console.WriteLine("Download Started...");
            if (!File.Exists(finalDestination)) {

                new WebClient().DownloadFile(
                                    new Uri(file.Link),
                                    finalDestination
                                );
                Console.WriteLine("Download Finished...");
            }
            else
                Console.WriteLine("File Exists: " + finalDestination);
            
        }

        #endregion

    }
}
