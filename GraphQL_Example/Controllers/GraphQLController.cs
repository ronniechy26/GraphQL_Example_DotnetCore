using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL_Example.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_Example.Controllers
{
    [Route("api/[controller]")]
    public class GraphQLController : ControllerBase
    {
        public readonly ISchema schema;
        public readonly IDocumentExecuter documentExecuter;
        public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            this.schema = schema;
            this.documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> post([FromBody] GraphQLQuery query)
        {
            if (query == null)
            {
                throw new NullReferenceException(nameof(query));
            }

            Inputs inputs = query.Variables?.ToInputs();
            ExecutionOptions executionOptions = new ExecutionOptions()
            {
                Schema = schema,
                Query = query.Query,
                Inputs = inputs
            };

            ExecutionResult result = await documentExecuter.ExecuteAsync(executionOptions);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }

    }
}