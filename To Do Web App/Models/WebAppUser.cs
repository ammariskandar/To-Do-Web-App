using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace mvc.Models
{
    public class WebAppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<TodoItem> TodoItems { get; set; }
    }
}