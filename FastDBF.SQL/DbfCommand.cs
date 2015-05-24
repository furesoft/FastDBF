using FastDBF.SQL.Statements;
using SocialExplorer.IO.FastDBF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDBF.SQL
{
    public class DbfCommand
    {
        private DbfConnection _connection;
        private DbfFile _file;

        internal DbfCommand(DbfConnection con, DbfFile file)
        {
            _connection = con;
            _file = file;
        }

        public string CommandText { get; set; }

        public DbfRessource ExecuteQuery()
        {
            var ret = new DbfRessource();

            var stmt = SqlParser.ParseStatement(CommandText);
            if (stmt is SelectStatement)
            {
                var select = (SelectStatement)stmt;

                for (int i = 0; i < _file.Header.RecordCount; i++)
                {
                    for (int j = 0; j < _file.Header.ColumnCount; j++)
                    {
                        string result;

                        _file.ReadValue(i, j, out result);

                        ret.Add(result);
                    }
                }
            }

            return ret;
        }

        public void ExecuteNonQuery()
        {
            ExecuteQuery();
        }
    }
}