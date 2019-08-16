using GraphQL;
using GraphQL_Example.Mutations;
using GraphQL_Example.Queries;

namespace GraphQL_Example.Schema
{
    public class Schema : GraphQL.Types.Schema
    {
        public Schema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<AppUserQuery>();
            Mutation = resolver.Resolve<AppUserMutation>();
        }
    }
}
