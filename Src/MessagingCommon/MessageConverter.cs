using Dafist.Engine.Updates;

namespace Dafist.MessagingCommon
{
    public interface MessageConverter<T>
    {
        SourceUpdate Convert(T x);
    }
}