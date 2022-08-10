using Dafist.Engine.Get;

namespace Dafist.Engine.Composing.GetPart
{
    public interface GetPartComposer
    {
        GettingManager Compose(CommonObjects c);
    }
}