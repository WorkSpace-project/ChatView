using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatView.Models.DataContext
{
    public class Mcustomer
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string CustomerCode { get; set; }
        [MaxLength(60)]
        public string FirstName { get; set; }
        [MaxLength(60)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
