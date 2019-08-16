using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_Example.Type
{
    public class AppUserInputType : InputObjectGraphType
    {
        public AppUserInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<StringGraphType>("middleName");
            Field<NonNullGraphType<IntGraphType>>("rank");
            Field<NonNullGraphType<StringGraphType>>("department");
            Field<NonNullGraphType<StringGraphType>>("userStatus");
            Field<NonNullGraphType<StringGraphType>>("userType");
        }
    }
}
