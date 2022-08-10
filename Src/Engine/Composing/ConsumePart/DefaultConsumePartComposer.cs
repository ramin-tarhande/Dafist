using System.Collections.Generic;
using System.Linq;
using Dafist.Engine.Consume;
using Dafist.Engine.Consume.Map;
using Dafist.Engine.Consume.Top;
using Dafist.Engine.ObjectFactories;
using Dafist.Engine.Resilience.SafeExecution;

namespace Dafist.Engine.Composing.ConsumePart
{
    public class DefaultConsumePartComposer : ConsumePartComposer
    {
        private readonly IEnumerable<ConsumeObjectsFactory> consumeObjectsFactories;
        public DefaultConsumePartComposer(IEnumerable<ConsumeObjectsFactory> consumeObjectsFactories)
        {
            this.consumeObjectsFactories = consumeObjectsFactories;
        }

        public DefaultConsumePartComposer(ConsumeObjectsFactory consumeObjectsFactory)
            :this(new []{consumeObjectsFactory})
        {
            
        }

        public ConsumingManager Compose(CommonObjects c)
        {
            var progress = c.Progress;
            SetFailed setFailed = () => progress.ConsumeState = ConsumeState.Failed;

            var mapper = CreateMapper(setFailed,c);

            var consumers = CreateConsumers(setFailed,c)
                .ToList(); //necessary!

            //
            var consumeDirector = new ConsumeDirector(mapper, consumers,c.Schema, c.Buffer, progress, c.Log);
            var consumingManager = new ConsumeDriver(consumeDirector, c.QuitApp, c.Log);

            return consumingManager;
        }

        static ConsumeMapper CreateMapper(SetFailed setFailed, CommonObjects c)
        {
            var problemProcessor = new ProblemProcessor(
                new MappingPte(new MappingSee(c.Log)), c.Progress, setFailed, c.Log);

            var safeExecuter = new SafeExecuter(problemProcessor, 
                c.SafeExecutersClub, c.Settings, c.Log);

            //var computer = new Computer(safeExecuter, c.Log);

            var mapper = new ConsumeMapper(safeExecuter, c.Log);

            return mapper;
        }

        IEnumerable<Consumer> CreateConsumers(SetFailed setFailed, CommonObjects c)
        {
            foreach (var consumeObjectsFactory in consumeObjectsFactories)
            {
                var consumer = CreateConsumer(consumeObjectsFactory, setFailed, c);
                yield return consumer;
            }
        }

        static Consumer CreateConsumer(ConsumeObjectsFactory consumeObjectsFactory, SetFailed setFailed, CommonObjects c)
        {
            var problemTypeExpert = consumeObjectsFactory.CreateProblemTypeExpert();
            //
            var problemProcessor = new ProblemProcessor(problemTypeExpert, c.Progress, setFailed, c.Log);

            var safeExecuter = new SafeExecuter(problemProcessor, c.SafeExecutersClub, c.Settings, c.Log);

            var consumer = consumeObjectsFactory.CreateConsumer(safeExecuter,c.Progress);

            return consumer;
        }
    }
}
