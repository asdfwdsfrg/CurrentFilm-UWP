using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using CurrentFilm.Models;
using System.Runtime.Serialization.Json;

namespace CurrentFilm.Service
{
    public static class JsonToObject
    {
        public static T DataContract<T>(string jsonString)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            var data = (T)serializer.ReadObject(ms);
            return data;
        }
    }
}
