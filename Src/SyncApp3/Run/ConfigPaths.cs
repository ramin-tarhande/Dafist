namespace SyncApp3.Run
{
    public class ConfigPaths
    {
        const string folder = "ConfigFiles";
        
        public static string MainConfig()
        {
            return MakePath("SyncApp3.yml");
        }

        public static string LogConfig()
        {
            return MakePath("SyncApp3.log.config");
        }

        static string MakePath(string file)
        {
            return System.IO.Path.Combine(folder, file);
        }
    }
}
