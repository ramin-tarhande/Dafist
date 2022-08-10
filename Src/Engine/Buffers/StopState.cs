namespace Dafist.Engine.Buffers
{
    public struct StopState
    {
        public bool Stopped { get; private set; }
        public StopState(bool stopped) : this()
        {
            Stopped = stopped;
        }
    }
}