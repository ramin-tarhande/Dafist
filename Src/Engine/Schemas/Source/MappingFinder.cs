using System;
using System.Collections.Generic;

namespace Dafist.Engine.Schemas.Source
{
    public abstract class MappingFinder
    {
        public abstract Mapping GetFor(ConsumerBasics consumer);

        public class Fixed : MappingFinder
        {
            private readonly Mapping mapping;
            public Fixed(Mapping mapping)
            {
                this.mapping = mapping;
            }

            public override Mapping GetFor(ConsumerBasics consumer)
            {
                return mapping;
            }
        }
        
        public static IdBasedLookup CreateIdBasedLookup()
        {
            return new IdBasedLookup();
        }

        public class IdBasedLookup : MappingFinder
        {
            private readonly Dictionary<object, Mapping> mappings;
            private readonly Mapping defaultMapping;
            public IdBasedLookup(Mapping defaultMapping = null)
            {
                this.mappings = new Dictionary<object, Mapping>();
                this.defaultMapping = defaultMapping;
            }

            public IdBasedLookup Add(object consumerId, Mapping mapping)
            {
                mappings[consumerId] = mapping;
                return this;
            }

            public override Mapping GetFor(ConsumerBasics consumer)
            {
                Mapping mapping;
                var found = mappings.TryGetValue(consumer.Id, out mapping);
                if (!found)
                {
                    mapping = defaultMapping;
                }

                return mapping;
            }
        }

        public class FuncBased : MappingFinder
        {
            private readonly Func<ConsumerBasics, Mapping> func;
            public FuncBased(Func<ConsumerBasics, Mapping> func)
            {
                this.func = func;
            }

            public override Mapping GetFor(ConsumerBasics consumer)
            {
                return func(consumer);
            }
        }

    }
}
