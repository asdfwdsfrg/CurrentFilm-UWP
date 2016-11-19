using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace CurrentFilm.Models
{
    [DataContract]
    public class Film
    {
        [DataMember]
        public int count { get; set; }
        [DataMember]
        public int start { get; set; }
        [DataMember]
        public int total { get; set; }
        [DataMember]
        public Subject[] subjects { get; set; }
        [DataMember]
        public string title { get; set; }
    }
    [DataContract]
    public class Subject
    {
        public string getActor
        {
            get { return getActorMethod(); }
            set { }
        }
        public string getDirector
        {
            get { return getDirectorMethod(); }
            set { }
        }

        public string getGenres
        {
            get { return getGenresMethod(); }
            set { }
        }
        public string getGenresMethod()
        {
            string temp = "";
            foreach (string a in genres)
            {
                temp += a + " ";
            }
            return temp;
        }
        public string getActorMethod()
        {
            string temp = "";
            foreach (Cast a in casts)
            {
                temp += a.name + " ";
            }
            return temp;
        }
        public string getDirectorMethod()
        {
            string temp = "";
            foreach (Director a in directors)
            {
                temp += a.name + " ";
            }
            return temp;
        }
        [DataMember]
        public Rating rating { get; set; }
        [DataMember]
        public string[] genres { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public Cast[] casts { get; set; }
        [DataMember]
        public string[] durations { get; set; }
        [DataMember]
        public int collect_count { get; set; }
        [DataMember]
        public string mainland_pubdate { get; set; }
        [DataMember]
        public bool has_video { get; set; }
        [DataMember]
        public string original_title { get; set; }
        [DataMember]
        public string subtype { get; set; }
        [DataMember]
        public Director[] directors { get; set; }
        [DataMember]
        public string[] pubdates { get; set; }
        [DataMember]
        public string year { get; set; }
        [DataMember]
        public Images images { get; set; }
        [DataMember]
        public string alt { get; set; }
        [DataMember]
        public string id { get; set; }
    }
}
    [DataContract]
    public class Rating
    {
        [DataMember]
        public int max { get; set; }
        [DataMember]
        public float average { get; set; }
        [DataMember]
        public Details details { get; set; }
        [DataMember]
        public string stars { get; set; }
        [DataMember]
        public int min { get; set; }
    }
    [DataContract]
    public class Details
    {
        [DataMember]
        public int _1 { get; set; }
        [DataMember]
        public int _3 { get; set; }
        [DataMember]
        public int _2 { get; set; }
        [DataMember]
        public int _5 { get; set; }
        [DataMember]
        public int _4 { get; set; }
    }
    [DataContract]
    public class Images
    {
        [DataMember]
        public string small { get; set; }
        [DataMember]
        public string large { get; set; }
        [DataMember]
        public string medium { get; set; }
    }

    [DataContract]
    public class Cast
    {
        [DataMember]
        public Avatars avatars { get; set; }
        [DataMember]
        public string name_en { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string alt { get; set; }
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class Avatars
    {
        [DataMember]
        public string small { get; set; }
        [DataMember]
        public string large { get; set; }
        [DataMember]
        public string medium { get; set; }
    }
    [DataContract]
    public class Director
    {
        [DataMember]
        public Avatars1 avatars { get; set; }
        [DataMember]
        public string name_en { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string alt { get; set; }
        [DataMember]
        public string id { get; set; }
    }
    [DataContract]
    public class Avatars1
    {
        [DataMember]
        public string small { get; set; }
        [DataMember]
        public string large { get; set; }
        [DataMember]
        public string medium { get; set; }
    }

