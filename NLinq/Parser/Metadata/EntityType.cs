using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Parser.Metadata
{
    public class EntityType : BaseType
    {
        public EntitySet EntitySet;

        public EntityType(EntitySet entitySet)
            :base (entitySet.EntityType)
        {
            this.EntitySet = entitySet;
        }
    }
}
