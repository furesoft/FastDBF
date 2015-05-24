using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDBF.SQL.Statements
{
    internal class SelectStatement : ISqlStatement
    {
        public string Column { get; set; }
    }
}