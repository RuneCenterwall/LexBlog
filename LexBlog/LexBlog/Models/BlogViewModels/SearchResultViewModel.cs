﻿using LexBlog.Models.BlogDBModels;
using LexBlog.Models.BlogViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexBlog.Models.BlogViewModels
{
    public class SearchResultViewModel
    {
        public string SearchString { get; set; }
        public List<Post> Posts { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}