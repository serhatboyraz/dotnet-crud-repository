using System;
using CrudRepositoryExample.DataAccess.GraphQueries;
using GraphQL.Types;

namespace CrudRepositoryExample.DataAccess.GraphSchemas
{
    /// <summary>
    /// Project graphql schema
    /// </summary>
    public class ProjectSchema : Schema
    {
        public ProjectSchema(Func<Type, GraphType> resolveType) : base(resolveType)
        {
            Query = (ProjectQuery)resolveType(typeof(ProjectQuery));
        }
    }
}
