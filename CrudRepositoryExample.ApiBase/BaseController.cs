using System;
using System.Linq.Expressions;
using CrudRepositoryExample.DataAccess.UnitOfWork;
using CrudRepositoryExample.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CrudRepositoryExample.ApiBase
{
    public class BaseController<T> : Controller where T : class
    {
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

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(long id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                ParameterExpression argParams = Expression.Parameter(typeof(T), "x");
                Expression filterProp = Expression.Property(argParams, "Id");
                ConstantExpression filterValue = Expression.Constant(id);
                var expression = Expression.Lambda<Func<T, bool>>(Expression.Equal(filterProp, filterValue), argParams);
                T item = uow.GetRepository<T>().Get(expression);
                if (item != null)
                    uow.GetRepository<T>().Delete(item);
                else
                    return StatusCode(404);

                return StatusCode(uow.SaveChanges() > 0 ? 200 : 500);
            }
        }
        [Route("{id}")]
        [HttpPost]
        public IActionResult Update(long id, [FromBody] T updateItem)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                ParameterExpression argParams = Expression.Parameter(typeof(T), "x");
                Expression filterProp = Expression.Property(argParams, "Id");
                ConstantExpression filterValue = Expression.Constant(id);
                var expression = Expression.Lambda<Func<T, bool>>(Expression.Equal(filterProp, filterValue), argParams);
                T item = uow.GetRepository<T>().Get(expression);
                if (item == null)
                    return StatusCode(404);
                ObjectMapper.MapExclude(item, updateItem, new string[] { "Id" });

                uow.GetRepository<T>().Update(item);

                return StatusCode(uow.SaveChanges() > 0 ? 200 : 500);
            }
        }

    }
}
