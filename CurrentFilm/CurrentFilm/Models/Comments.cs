using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentFilm.Models
{
    public class Comments
    {
        public int count { get; set; }
        public Comment[] comments { get; set; }
        public int start { get; set; }
        public int total { get; set; }
        public int next_start { get; set; }
        public Subject subject { get; set; }
    }
    public class Comment
    {
        public Rating rating { get; set; }
        public int useful_count { get; set; }
        public Author author { get; set; }
        public string subject_id { get; set; }
        public string content { get; set; }
        public string created_at { get; set; }
        public string id { get; set; }
    }
    public class Author
    {
        public string uid { get; set; }
        public string avatar { get; set; }
        public string signature { get; set; }
        public string alt { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }
}
