using System.Linq;
using CrudRepositoryExample.Data.Model;
using CrudRepositoryExample.DataAccess.UnitOfWork;
using GraphQL.Types;

namespace CrudRepositoryExample.DataAccess.GraphTypes
{
    /// <summary>
    /// Project graphql type
    /// </summary>
    public class ProjectGraphType : ObjectGraphType<ProjectModel>
    {
        public ProjectGraphType(IUnitOfWork uow)
        {
            Field(x => x.Id).Description("Project Id");
            Field(x => x.Title, true).Description("Project Title");

            Field<ListGraphType<UserGraphType>>(
                "roles",
                resolve: context => uow.GetRepository<ProjectRoleModel>().GetAll(x => x.ProjectId == context.Source.Id).Select(x => x.User).ToList()
            );

            Field<ListGraphType<ToDoGraphType>>(
                "todos",
                resolve: context =>
                    uow.GetRepository<ToDoModel>().GetAll(x => x.ProjectId == context.Source.Id).ToList()
            );
        }
    }
}
