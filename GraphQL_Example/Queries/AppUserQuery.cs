using GraphQL.Types;
using GraphQL_Example.DataAccessLayer.HelperClass;
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
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "search"},
                                              new QueryArgument<StringGraphType> { Name = "sortBy"},
                                              new QueryArgument<IntGraphType> { Name = "page" }, 
                                              new QueryArgument<IntGraphType> { Name = "pageSize" }),
                resolve: context =>
                {
                    var filter = new AppUserFilter()
                    {
                        Search = context.GetArgument<string>("search"),
                        Page = context.GetArgument<int>("page"),
                        PageSize = context.GetArgument<int>("pageSize"),
                        SortBy = context.GetArgument<String>("sortBy")
                    };
                    return appUser.GetApplicationUsers(filter);
                });

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
