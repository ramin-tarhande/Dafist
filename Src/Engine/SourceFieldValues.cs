namespace Dafist.Engine
{
    public interface SourceFieldValues
    {
        object this[string fieldName] { get; }
    }
}