using GraphQL.Types;
using GraphQL_Example.DataAccessLayer.Implementation;
using GraphQL_Example.DataAccessLayer.Repository;
using GraphQL_Example.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Example.Type
{
    public class AppUserType : ObjectGraphType<ApplicationUser>
    {
        public AppUserType(ITransactionRepository transactionRepository)
        {
            Field(x => x.Id);
            Field(x => x.firstName);
            Field(x => x.lastName);
            Field(x => x.middleName);
            Field(x => x.rank);
            Field(x => x.department);
            Field(x => x.userStatus);
            Field(x => x.userType);
            Field(x => x.DateAcctCreated);
            Field<ListGraphType<TransactionType>>("transactions",
                                                   arguments : new QueryArguments(new QueryArgument<IntGraphType> { Name = "last" }),
                                                   resolve: context =>
                                                   {
                                                       var last = context.GetArgument<int?>("last");
                                                       return last != null ? transactionRepository.GetTransactions(context.Source.Id.ToString(), last.Value)
                                                                           : transactionRepository.GetTransactions(context.Source.Id.ToString());
                                                   });
        }
    }
}
