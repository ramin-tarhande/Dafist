namespace Dafist.Shared
{
    public enum UpdateType
    {
        Deleted, Created, Modified, 

        /// <summary>
        /// for cases when 'Get' part couldn't or simply doesn't care to distinguish between the two
        /// </summary>
        CreatedOrModified
    }
}