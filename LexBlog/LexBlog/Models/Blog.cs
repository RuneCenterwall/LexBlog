using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LexBlog.Models
{
    public class Blog
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime Created { get; set; }
        [DisplayFormat(DataFormatString = "{0:MMM dd, yyyy}")]
        public DateTime Edited { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public int Views { get; set; }    
        
             

    }
}