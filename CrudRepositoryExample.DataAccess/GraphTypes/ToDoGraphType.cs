using System.Linq;
using CrudRepositoryExample.Data.Model;
using CrudRepositoryExample.DataAccess.UnitOfWork;
using GraphQL.Types;

namespace CrudRepositoryExample.DataAccess.GraphTypes
{
    /// <summary>
    /// ToDo graphql type
    /// </summary>
    public class ToDoGraphType : ObjectGraphType<ToDoModel>
    {
        public ToDoGraphType(IUnitOfWork uow)
        {
            Field(x => x.Id).Description("Ticket Id");
            Field(x => x.Subject).Description("Ticket Subject");            
        }
    }
}
