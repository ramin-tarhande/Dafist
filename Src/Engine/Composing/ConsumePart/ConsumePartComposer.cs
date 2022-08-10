using Dafist.Engine.Consume;

namespace Dafist.Engine.Composing.ConsumePart
{
    public interface ConsumePartComposer
    {
        ConsumingManager Compose(CommonObjects c);
    }
}
