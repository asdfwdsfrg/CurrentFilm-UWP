using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentFilm.Services
{
    class UriBuilder
    {
        public static string BuildUri(String uri, Dictionary<string,string> paramaters)
        {
            StringBuilder tempUri = new StringBuilder(uri);
            foreach(KeyValuePair<string,string> x in paramaters)
            {
                tempUri.AppendFormat("&{0}={1}", x.Key, x.Value);
            }
            return tempUri.ToString();
        }
    }
}
