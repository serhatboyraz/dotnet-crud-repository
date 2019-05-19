using CrudRepositoryExample.Data.Enum;
using CrudRepositoryExample.Data.Model;
using CrudRepositoryExample.DataAccess.GraphTypes;
using CrudRepositoryExample.DataAccess.UnitOfWork;
using GraphQL.Types;

namespace CrudRepositoryExample.DataAccess.GraphQueries
{
    /// <summary>
    /// Project graph query
    /// </summary>
    public class ProjectQuery : ObjectGraphType
    {
        public ProjectQuery(IUnitOfWork uow)
        {
            Field<ProjectGraphType>(
                "project",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id", Description = "Project Id" }
                ),
                resolve: context =>
                {
                    long id = context.GetArgument<long>("id");
                    return uow.GetRepository<ProjectModel>().Get(x => x.Id == id);
                });

            Field<ListGraphType<ProjectGraphType>>(
                "projects",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "status", Description = "Project Status" }
                ),
                resolve: context =>
                {
                    ProjectStatusEnum status = context.GetArgument<ProjectStatusEnum>("status");
                    return uow.GetRepository<ProjectModel>().GetAll(x => x.Status == status);
                });
        }
    }
}
