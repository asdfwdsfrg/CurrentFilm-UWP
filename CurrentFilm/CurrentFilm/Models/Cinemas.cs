using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentFilm.Models
{
    public class Rootobject
    {
        public string title { get; set; }
        public int total { get; set; }
        public Entry[] entries { get; set; }
    }

    public class Entry
    {
        public string schedule_url { get; set; }
        public string title { get; set; }
        public string abbreviated_title { get; set; }
        public string[] phone { get; set; }
        public bool is_favorite { get; set; }
        public Location location { get; set; }
        public Images images { get; set; }
        public string alt { get; set; }
        public bool bookable { get; set; }
        public string id { get; set; }
        public bool has_tuan { get; set; }
    }

    public class Location
    {
        public string city { get; set; }
        public string district { get; set; }
        public float distance { get; set; }
        public string map_url { get; set; }
        public string address { get; set; }
        public Coordinate coordinate { get; set; }
    }

    public class Coordinate
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
    }
    public class CoordinateString
    {
        public string latitude { get; set; }
        public string longtitude { get; set; }
    }
}
