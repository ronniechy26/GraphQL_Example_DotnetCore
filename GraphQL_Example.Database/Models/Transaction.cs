using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_Example.Database.Models
{
    public class Transaction
    {
        public int id { get; set; }
        public int Balance { get; set; }
        public int Payment { get; set; }
        public string remarks { get; set; }
        public string ApplicationUserId { get; set; }

    }
}
