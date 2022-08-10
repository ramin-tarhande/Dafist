namespace Dafist.MsSqlAdp.Get
{
    class PkPrefixer
    {
        private const string prefixText = "Pk_";

        public static string Prefix(string fieldName)
        {
            return prefixText + fieldName;
        }

    }
}
