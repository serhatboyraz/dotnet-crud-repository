using System.Linq;
using CrudRepositoryExample.Data.Model;
using CrudRepositoryExample.DataAccess.UnitOfWork;
using CrudRepositoryExample.Utils.Extensions;
using CrudRepositoryExample.Utils.ObjectMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudRepositoryExample.ApiBase.Controlers
{
    /// <summary>
    /// CrudController is a generic crud operations based WebApi controller.
    /// This controller contains only base CRUD operations.
    /// </summary>
    public class CrudController<T> : Controller where T : class
    {

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(long id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repository = uow.GetRepository<T>();
                T item = repository.GetAll(id.GetIdentifierExpression<T>())
                    .Include(repository.GetDbContext().GetIncludePaths(typeof(T))).FirstOrDefault();

                if (item == null)
                    return StatusCode(404);
                return Json(item);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody]T item)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                uow.GetRepository<T>().Add(item);
                uow.SaveChanges();
            }
            return Json(item);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                T item = uow.GetRepository<T>().Get(id.GetIdentifierExpression<T>());
                if (item == null)
                    return StatusCode(404);

                uow.GetRepository<T>().Delete(item);
                return StatusCode(uow.SaveChanges() > 0 ? 200 : 500);
            }
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult Update(long id, [FromBody] T updateItem)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                T item = uow.GetRepository<T>().Get(id.GetIdentifierExpression<T>());
                if (item == null)
                    return StatusCode(404);

                ObjectMapper.MapExclude(item, updateItem, new string[] {typeof(T).GetIdentifierColumnName()});
                uow.GetRepository<T>().Update(item);
                return StatusCode(uow.SaveChanges() > 0 ? 200 : 500);
            }
        }

    }
}
