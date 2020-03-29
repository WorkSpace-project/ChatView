using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatView.Models.Users
{
    public class UserModal
    {
        public Guid Id { get; set; }
        public string CustomerCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
