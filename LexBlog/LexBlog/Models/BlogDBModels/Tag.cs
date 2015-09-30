using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexBlog.Models.BlogDBModels
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}