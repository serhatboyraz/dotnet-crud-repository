﻿using System;
using System.Collections.Generic;
using System.Text;
using CrudRepositoryExample.Data.Model;
using CrudRepositoryExample.Utils.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CrudRepositoryExample.Data.Context
{
    public class MasterContext : DbContext
    {
        public MasterContext()
        {

        }

        public MasterContext(DbContextOptions<MasterContext> dbContext)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySQL(ConnectionExtensions.GetConnectionString());
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProjectModel> Project { get; set; }
        public DbSet<ProjectRoleModel> ProjectRole { get; set; }
        public DbSet<ToDoModel> ToDo { get; set; }
    }
}
