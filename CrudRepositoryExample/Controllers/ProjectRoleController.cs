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
    [Route("ProjectRole")]
    public class ProjectRoleController : CrudController<ProjectRoleModel>
    {
        [Route("Roles/{projectId}")]
        [HttpGet]
        public IActionResult GetProjectRoleList(long projectId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return Json(uow.GetRepository<ProjectRoleModel>()
                    .GetAll(x => x.Project.Id == projectId)
                    .Include(x => x.User).ToList());
            }
        }
         
    }
}