using SocialExplorer.IO.FastDBF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDBF.SQL
{
    public class DbfReader
    {
        private DbfConnection _connection;
        private DbfFile _file;

        public DbfReader(DbfConnection con)
        {
            _connection = con;
            _file = new DbfFile();
            _file.Open(_connection.Catalog, System.IO.FileMode.OpenOrCreate);
        }

        public DbfCommand CreateCommand()
        {
            return new DbfCommand(_connection, _file);
        }
    }
}