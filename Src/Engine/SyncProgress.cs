namespace Dafist.Engine
{
    public interface SyncProgress
    {
        int Gets { get; }
        int Consumes { get; }
        int Failures { get; }
        int Invalids { get; }
        int BufferSize { get; }

        GetState GetState { get; }
        ConsumeState ConsumeState { get; }
    }
}