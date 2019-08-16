using GraphQL_Example.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL_Example.DataAccessLayer.Repository
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactions(string id);
        IEnumerable<Transaction> GetTransactions(string id, int? last);
    }
}
