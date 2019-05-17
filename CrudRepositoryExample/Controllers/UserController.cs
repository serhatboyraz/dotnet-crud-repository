﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudRepositoryExample.ApiBase;
using CrudRepositoryExample.ApiBase.Controlers;
using CrudRepositoryExample.Data.Model; 
using Microsoft.AspNetCore.Mvc;

namespace CrudRepositoryExample.Controllers
{
    [Route("User")]
    public class UserController : CrudController<UserModel>
    {

    }
}