using FastDBF.SQL.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FastDBF.SQL
{
    internal class SqlParser
    {
        public const string SelectStmt = "SELECT (?<column>([a-z0-9]*|\\*))";

        public static ISqlStatement ParseStatement(string sql)
        {
            var selectRegex = new Regex(SelectStmt, RegexOptions.Singleline);
            var selectMatch = selectRegex.Match(sql);

            if (selectMatch.Success)
            {
                var stmt = new SelectStatement();
                stmt.Column = selectMatch.Groups["column"].Value;

                return stmt;
            }
            else
            {
                throw new InvalidSqlStatement();
            }
        }
    }
}