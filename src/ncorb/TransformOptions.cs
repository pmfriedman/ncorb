
namespace ncorb
{
    public class TransformOptions
    {
        public static readonly int SLEEP_TIME_MS = 500;
        public static readonly long PROGRESS_INTERVAL_MS = 60 * SLEEP_TIME_MS;
        public static readonly string NAME = typeof(TransformOptions).Name;
        public static readonly string COLLECTION_TYPE = "COLLECTION";
        public static readonly string DIRECTORY_TYPE = "DIRECTORY";
        public static readonly string QUERY_TYPE = "QUERY";

        private static readonly string SLASH = "/";
        private static readonly char SLASHCHAR = SLASH.ToCharArray()[0];

        public string XDBC_Root { get; set; }
        public int ThreadCount { get; set; }
        public string LogLevel { get { return "INFO"; } }
        public string LogHandler { get { return "CONSOLE"; } }
        public string ModulesDatabase { get; set; }
        public string UrisModule { get; set; }
        public string ProcessModule { get; set; }
        public string ModuleRoot { get; set; }
        public bool ShouldDoInstall { get; set; }
        public int QueueSize { get { return 100 * 1000; } }

        public TransformOptions()
        {
            ModuleRoot = SLASH + typeof(TransformOptions).FullName.Replace('.', SLASHCHAR) + SLASH;
            UrisModule = "get-uris.xqy";
            ShouldDoInstall = true;
            ModulesDatabase = "Modules";
        }

    }

}