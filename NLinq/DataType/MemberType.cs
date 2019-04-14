using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace NLinq.DataType
{
    public class MemberType : BaseType
    {
       public MemberInfo MemberInfo { get; set; }
        public MemberType(MemberInfo memberInfo)
            : base(memberInfo.GetPropertyOrFieldType())
        {
            this.MemberInfo = memberInfo;
        }
    }
}
