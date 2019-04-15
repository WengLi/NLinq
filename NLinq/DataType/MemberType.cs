using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace NLinq.DataType
{
    public class MemberType : BaseType
    {
        public MemberInfo MemberInfo { get; set; }
        public override DataTypeKind TypeKind => DataTypeKind.MemberType;
        public MemberType(MemberInfo memberInfo)
            : base(memberInfo.GetPropertyOrFieldType())
        {
            this.MemberInfo = memberInfo;
        }

        public override string ToString()
        {
            return MemberInfo.Name;
        }
    }
}
