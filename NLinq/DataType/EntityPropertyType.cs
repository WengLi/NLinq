﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace NLinq.DataType
{
    public class EntityPropertyType: MemberType
    {
        public EntityProperty EntityProperty { get; set; }

        public EntityPropertyType(EntityProperty entityProperty)
            : base(entityProperty.PropertyInfo)
        {
            this.EntityProperty = entityProperty;
        }
    }
}
