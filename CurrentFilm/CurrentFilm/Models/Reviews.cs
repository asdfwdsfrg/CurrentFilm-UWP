using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentFilm.Models
{
        public class Reviews
        {

        public int count { get; set; }
            public Review[] reviews { get; set; }
            public int start { get; set; }
            public int total { get; set; }
            public int next_start { get; set; }
            public Subject subject { get; set; }
        }


        public class Review
        {
            public Rating1 rating { get; set; }
            public int useful_count { get; set; }
            public Author author { get; set; }
            public string created_at { get; set; }
            public string title { get; set; }
            public string updated_at { get; set; }
            public string share_url { get; set; }
            public string summary { get; set; }
            public string content { get; set; }
            public int useless_count { get; set; }
            public int comments_count { get; set; }
            public string alt { get; set; }
            public string id { get; set; }
            public string subject_id { get; set; }
        }

        public class Rating1
        {
            public int max { get; set; }
            public int value { get; set; }
            public int min { get; set; }
        }
    }
