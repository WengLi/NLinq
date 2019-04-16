using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using NLinq.DataType;

namespace NLinq.DbExpressions
{
    public class DbMemberExpression : DbExpression
    {
        public MemberInfo MemberInfo { get; }

        public DbExpression Argument { get; }

        public DbMemberExpression(DbExpression arg, MemberInfo memberInfo)
            : base(DbExpressionKind.Member, new MemberType(memberInfo))
        {
            this.MemberInfo = memberInfo;
            this.Argument = arg;
        }
    }
}
