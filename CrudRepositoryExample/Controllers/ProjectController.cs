using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudRepositoryExample.ApiBase;
using CrudRepositoryExample.ApiBase.Controlers;
using CrudRepositoryExample.Data.Model;
using CrudRepositoryExample.DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudRepositoryExample.Controllers
{
    [Route("Project")]
    public class ProjectController : CrudController<ProjectModel>
    {

    }
}