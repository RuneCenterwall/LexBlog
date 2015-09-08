using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexBlog.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
    }
}