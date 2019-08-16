using GraphQL_Example.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_Example.Database
{
    public static class AppDbSeed
    {
        public static void Seed(this AppDbContext dbContext)
        {
           
            if (!dbContext.ApplicationUsers.Any())
            {
                for (int i =0; i< 5; i++)
                {
                    var user = new ApplicationUser()
                    {
                        firstName = "test" + i,
                        lastName = "test" + i,
                        rank = i,
                        department = "test",
                        userStatus = "active",
                        userType = "admin",
                        Transactions = new List<Transaction>()
                        {
                            new Transaction()
                            {
                                Balance = 10123 + i * i,
                                Payment = 678 + i * i,
                                remarks = "The remarks",
                            },
                            new Transaction()
                            {
                                Balance = 103 + i * i,
                                Payment = 6148 + i * i,
                                remarks = "The remarkssssss",
                            },
                            new Transaction()
                            {
                                Balance = 11423 + i * i,
                                Payment = 1478 + i * i,
                                remarks = "The remarksssssssssssss",
                            }
                        }
                    };
                    dbContext.ApplicationUsers.Add(user);
                }
                dbContext.SaveChanges();
            }
        }
    }
}
