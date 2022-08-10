namespace Dafist.Engine.Resilience.SafeExecution
{
    struct TryResult
    {
        public bool Success { get; private set; }
        public ReactionType Reaction { get; private set; }
        public TryResult(bool success, ReactionType reaction)
            : this()
        {
            Success = success;
            Reaction = reaction;
        }

        public bool ShouldRetry()
        {
            return this.Reaction == ReactionType.Retry;
        }
    }
}
