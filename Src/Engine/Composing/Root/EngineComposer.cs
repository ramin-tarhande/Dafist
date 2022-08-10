using log4net;
using Dafist.Engine.Composing.ConsumePart;
using Dafist.Engine.Composing.GetPart;
using Dafist.Engine.Facade;
using Dafist.Engine.Schemas.Top;

namespace Dafist.Engine.Composing.Root
{
    public class EngineComposer
    {
        private readonly SimpleDepencies simpleDependecies;
        private readonly Schema schema;
        private readonly GetPartComposer getPartComposer;
        private readonly ConsumePartComposer consumePartComposer;
        private readonly ILog log;
        public EngineComposer(SimpleDepencies simpleDependecies, Schema schema,
            GetPartComposer getPartComposer, ConsumePartComposer consumePartComposer)
        {
            this.schema = schema;
            this.consumePartComposer = consumePartComposer;
            this.getPartComposer = getPartComposer;
            this.simpleDependecies = simpleDependecies;
            this.log = simpleDependecies.Log;
        }

        public EngineFacade Compose()
        {
            log.Debug("Compose engine");

            var c = CommonObjects.Initialize(simpleDependecies,schema);
            
            var gettingManager = getPartComposer.Compose(c);

            var consumingManager = consumePartComposer.Compose(c);

            return new EngineFacade(gettingManager, consumingManager, 
                c.Buffer, c.SafeExecutersClub, c.Progress, log);
        }
    }
}
