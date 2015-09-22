using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public virtual Post Post { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}