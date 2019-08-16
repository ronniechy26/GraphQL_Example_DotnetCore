using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_Example.Database.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string firstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string lastName { get; set; }
        public string middleName { get; set; }
        [Required]
        public int rank { get; set; }
        [Required]
        public string department { get; set; }
        [Required]
        public string userStatus { get; set; }
        [Required]
        public string userType { get; set; }
        public DateTime DateAcctCreated { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
