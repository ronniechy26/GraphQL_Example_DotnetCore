using GraphQL.Types;
using GraphQL_Example.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Example.Type
{
    public class TransactionType : ObjectGraphType<Transaction>
    {
        public TransactionType()
        {
            Field( x => x.id);
            Field(x => x.Balance);
            Field(x => x.Payment);
            Field(x => x.remarks);
        }
    }
}
