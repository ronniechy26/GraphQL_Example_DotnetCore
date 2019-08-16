using GraphQL.Types;
using GraphQL_Example.DataAccessLayer.Repository;
using GraphQL_Example.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Example.Queries
{
    public class AppUserQuery : ObjectGraphType
    {
        public AppUserQuery(IAppUserRepository appUser)
        {
            Field<ListGraphType<AppUserType>>("users",
                resolve: context => appUser.GetApplicationUsers());

            Field<AppUserType>("user",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return appUser.GetByidAsync(id);
                });
           
        }
    }
}
