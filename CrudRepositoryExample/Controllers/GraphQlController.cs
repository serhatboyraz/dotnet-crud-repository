using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudRepositoryExample.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace CrudRepositoryExample.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter documentExecuter;
        private readonly ISchema schema;
        public GraphQLController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            this.documentExecuter = documentExecuter;
            this.schema = schema;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }
            var executionOptions = new ExecutionOptions { Schema = schema, Query = query.Query };
            try
            {
                var result = await documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);
                if (result.Errors?.Count > 0)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}