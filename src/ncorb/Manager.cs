using Marklogic.Xcc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncorb
{
    class Manager
    {
        private static readonly string NAME = typeof(Manager).Name;

        private ContentSource _contentSource;

        static void Main(string[] args)
        {
            var m = new Manager();
            m.PrepareContentSource();
            if (args.Length < 3)
            {
                usage();
                return;
            }

            Console.ReadLine();
        }

        private static void usage()
        {
            var err = Console.Error;
            err.WriteLine("\nusage:");
            err.WriteLine("\t" + NAME
                    + " xcc://user:password@host:port/[ database ]"
                    + " input-selector module-name.xqy"
                    + " [ thread-count [ uris-module [ module-root"
                    + " [ modules-database [ install ] ] ] ] ]");
        }

        private void PrepareContentSource()
        {
            Uri connectionUri = new Uri("http://localhost:8035");
            bool ssl = connectionUri.Scheme == "xccs";
            _contentSource = ContentSourceFactory.NewContentSource(connectionUri);
            //_contentSource = 
              //  ssl ? 
                //    ContentSourceFactory.NewContentSource(connectionUri, newTrustAnyoneOptions())
                  //  : ContentSourceFactory.NewContentSource(connectionUri);
        }
    }
}
