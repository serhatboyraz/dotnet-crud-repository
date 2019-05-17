using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudRepositoryExample.ApiBase;
using CrudRepositoryExample.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace CrudRepositoryExample.Controllers
{
    [Route("Project")]
    public class ProjectController : CrudController<ProjectModel>
    {

    }
}