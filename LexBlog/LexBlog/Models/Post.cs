using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public int Views { get; set; }
        public DateTime Edited { get; set; }
    }
}