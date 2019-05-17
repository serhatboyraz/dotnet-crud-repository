using Microsoft.AspNetCore.Mvc;

namespace CrudRepositoryExample.ApiBase
{
    public class BaseController<T> : Controller where T : class
    {
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return Json(typeof(T).Name);
        }
    }
}
