using System;
using System.Collections.Generic;
using System.Text;

namespace NLinq.Sql
{
    public interface ISqlPart
    {
        void WriteSql(SqlWriter writer, SqlGenerator sqlGenerator);
    }
}
