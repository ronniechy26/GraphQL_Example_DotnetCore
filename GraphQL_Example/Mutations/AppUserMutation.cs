using GraphQL.Types;
using GraphQL_Example.DataAccessLayer.Repository;
using GraphQL_Example.Database.Models;
using GraphQL_Example.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Example.Mutations
{
    public class AppUserMutation : ObjectGraphType
    {
        public AppUserMutation(IAppUserRepository appUserRepository)
        {
            Field<AppUserType>(
                "addUser",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AppUserInputType>> { Name = "user" }),
                resolve: context =>
               {
                   return appUserRepository.AddUser(context.GetArgument<ApplicationUser>("user"));
               });

            Field<AppUserType>(
                "deleteUser",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
               {
                   return appUserRepository.DeleteUser(context.GetArgument<string>("id"));
               });
        }
    }
}
