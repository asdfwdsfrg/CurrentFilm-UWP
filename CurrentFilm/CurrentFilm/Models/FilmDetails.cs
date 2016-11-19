using System.Runtime.Serialization;

namespace CurrentFilm.Models
{
    [DataContract]
    public class FilmDetails
    {
        [DataMember]
        public Rating rating { get; set; }
        [DataMember]
        public int reviews_count { get; set; }
        [DataMember]
        public int wish_count { get; set; }
        [DataMember]
        public string douban_site { get; set; }
        [DataMember]
        public string year { get; set; }
        [DataMember]
        public Images images { get; set; }
        [DataMember]
        public string alt { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string mobile_url { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public object do_count { get; set; }
        [DataMember]
        public string share_url { get; set; }
        [DataMember]
        public object seasons_count { get; set; }
        [DataMember]
        public string schedule_url { get; set; }
        [DataMember]
        public object episodes_count { get; set; }
        [DataMember]
        public string[] countries { get; set; }
        [DataMember]
        public string[] genres { get; set; }
        [DataMember]
        public int collect_count { get; set; }
        [DataMember]
        public Cast[] casts { get; set; }
        [DataMember]
        public object current_season { get; set; }
        [DataMember]
        public string original_title { get; set; }
        [DataMember]
        public string summary { get; set; }
        [DataMember]
        public string subtype { get; set; }
        [DataMember]
        public Director[] directors { get; set; }
        [DataMember]
        public int comments_count { get; set; }
        [DataMember]
        public int ratings_count { get; set; }
        [DataMember]
        public string[] aka { get; set; }
    }
}