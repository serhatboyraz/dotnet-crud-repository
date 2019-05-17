using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CrudRepositoryExample
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
