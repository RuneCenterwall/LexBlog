using LexBlog.Models.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LexBlog.Models.BlogViewModels
{
    public class CreateViewModel
    {
        [Required]
        //[Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        //[Display(Name = "Description")]
        public string Description { get; set; }
    }

        //[Required]
    public class BlogListByViewsViewModel

    {
        public int Views { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }

    public class TagViewModel

    {
        //[Required]
        //[Display(Name = "Tags")]
        //public int Id { get; set; }
        //public string Name { get; set; }
        //new List<Tag>

    }

}