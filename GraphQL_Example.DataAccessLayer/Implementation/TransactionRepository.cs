using GraphQL_Example.DataAccessLayer.Repository;
using GraphQL_Example.Database;
using GraphQL_Example.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_Example.DataAccessLayer.Implementation
{
    public class TransactionRepository : ITransactionRepository
    {
        public TransactionRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public AppDbContext dbContext { get; }

        public IEnumerable<Transaction> GetTransactions(string id)
        {
            var transactions = dbContext.Transaction
                .Where(x => x.ApplicationUserId == id.ToString())
                .ToList();

            return transactions;
        }

        public IEnumerable<Transaction> GetTransactions(string id, int? last = 10)
        {
            var transactions = dbContext.Transaction
                .Where(x => x.ApplicationUserId == id.ToString())
                .Take(last ?? 10).ToList();

            return transactions;
        }
    }
}
