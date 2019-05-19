using System.Linq;
using CrudRepositoryExample.Data.Model;
using CrudRepositoryExample.DataAccess.UnitOfWork;
using GraphQL.Types;

namespace CrudRepositoryExample.DataAccess.GraphTypes
{
    /// <summary>
    /// User graphql type
    /// </summary>
    public class UserGraphType : ObjectGraphType<UserModel>
    {
        public UserGraphType(IUnitOfWork uow)
        {
            Field(x => x.Id).Description("User Id");
            Field(x => x.UserName).Description("User name");
          

        }
    }
}
