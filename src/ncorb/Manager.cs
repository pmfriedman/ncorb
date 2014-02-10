using Marklogic.Xcc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncorb
{
    public class Manager
    {
        private static readonly string NAME = typeof(Manager).Name;

        private ContentSource _contentSource;

        public TransformOptions Options { get; private set; }

        public static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                usage();
                return;
            }

            // gather inputs
            Uri connectionUri = new Uri(args[0]);
            string collection = args[1];

            Manager tm = new Manager(connectionUri, collection);

            // options
            TransformOptions options = tm.Options;

            options.ProcessModule = args[2];

            if (args.Length > 3 && args[3] != string.Empty)
                options.ThreadCount = int.Parse(args[3]);
            if (args.Length > 4 && args[4] != string.Empty)
                options.UrisModule = args[4];
            if (args.Length > 5 && args[5] != string.Empty)
                options.ModuleRoot = args[5];
            if (args.Length > 6 && args[6] != string.Empty)
                options.ModulesDatabase = args[6];
            if (args.Length > 7 && args[7] != string.Empty)
            {
                if (args[7] == "false" || args[7] == "0")
                    options.ShouldDoInstall = false;
            }
            tm.Run();

            Console.ReadLine();
        }

        public Manager(Uri connectionUri, string collection)
        {
            Options = new TransformOptions();
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
            Uri connectionUri = new Uri("xcc://localhost:8035");
            bool ssl = connectionUri.Scheme == "xccs";
            _contentSource = ContentSourceFactory.NewContentSource(connectionUri);

            // TODO: ssl
            //_contentSource = 
              //  ssl ? 
                //    ContentSourceFactory.NewContentSource(connectionUri, newTrustAnyoneOptions())
                  //  : ContentSourceFactory.NewContentSource(connectionUri);
        }
    }
}
