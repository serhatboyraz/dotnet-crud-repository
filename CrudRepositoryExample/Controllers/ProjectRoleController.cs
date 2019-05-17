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
    public class ProjectRoleController : CrudController<ProjectModel>
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

        [Route("AddRole/{projectId}/{userId}")]
        [HttpGet]
        public IActionResult AddRole(long projectId, long userId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var user = uow.GetRepository<UserModel>().Get(x => x.Id == userId);
                if (user == null)
                    return StatusCode(404);

                var project = uow.GetRepository<ProjectModel>().Get(x => x.Id == projectId);
                if (project == null)
                    return StatusCode(404);

                var projectRole = uow.GetRepository<ProjectRoleModel>()
                    .Get(x => x.Project.Id == projectId && x.User.Id == userId);

                if (projectRole != null)
                    return StatusCode(409);
                projectRole = new ProjectRoleModel()
                {
                    Project = project,
                    User = user
                };
                uow.GetRepository<ProjectRoleModel>().Add(projectRole);
                if (uow.SaveChanges() > 0)
                    return Json(projectRole);

                return StatusCode(500);

            }
        }
    }
}