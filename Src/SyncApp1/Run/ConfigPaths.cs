namespace SyncApp1.Run
{
    public class ConfigPaths
    {
        const string folder = "ConfigFiles";
        
        public static string MainConfig()
        {
            return MakePath("SyncApp1.yml");
        }

        public static string LogConfig()
        {
            return MakePath("SyncApp1.log.config");
        }

        static string MakePath(string file)
        {
            return System.IO.Path.Combine(folder, file);
        }
    }
}
