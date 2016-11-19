using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CurrentFilm.Services
{
    [DataContract]
    public class Location
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        public string info { get; set; }
        [DataMember]
        public string infocode { get; set; }
        [DataMember]
        public string province { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string adcode { get; set; }
        [DataMember]
        public string rectangle { get; set; }
    }
}
