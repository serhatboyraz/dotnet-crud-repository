using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudRepositoryExample.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace CrudRepositoryExample.Controllers
{
    [Route("ToDo")]
    public class ToDoController : BaseController<ToDoModel>
    {
    }
}
