using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDBF.SQL
{
    public class ConnectionString : IEnumerable<KeyValuePair<string, string>>, IDisposable
    {
        private Dictionary<string, string> _data = new Dictionary<string, string>();
        
        // server=localhost port=8080 
        public ConnectionString(string src)
        {
            var parts = src.Split(' ');
            foreach (var pair in parts)
            {
                var kv = pair.Split('=');
                _data.Add(kv[0].ToLower(), kv[1]);
            }
        }

        public string this[string key]
        {
            get
            {
                return _data[key.ToLower()];
            }
        }

        public void Dispose()
        {
            _data.Clear();
            _data = null;
            GC.SuppressFinalize(this);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
}