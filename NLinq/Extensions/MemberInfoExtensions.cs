using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace NLinq
{
    public static class MemberInfoExtensions
    {
        public static Type GetPropertyOrFieldType(this MemberInfo member)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Property:
                    return ((PropertyInfo)member).PropertyType;
                case MemberTypes.Field:
                    return ((FieldInfo)member).FieldType;
                default:
                    return null;
            }
        }
    }
}
