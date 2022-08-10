namespace SyncApp2.Run
{
    public class ConfigPaths
    {
        const string folder = "ConfigFiles";
        
        public static string MainConfig()
        {
            return MakePath("SyncApp2.yml");
        }

        public static string LogConfig()
        {
            return MakePath("SyncApp2.log.config");
        }

        static string MakePath(string file)
        {
            return System.IO.Path.Combine(folder, file);
        }
    }
}
