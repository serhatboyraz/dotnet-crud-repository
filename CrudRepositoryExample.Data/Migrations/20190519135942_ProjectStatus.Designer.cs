﻿// <auto-generated />
using CrudRepositoryExample.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrudRepositoryExample.Data.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20190519135942_ProjectStatus")]
    partial class ProjectStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("CrudRepositoryExample.Data.Model.ProjectModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Status");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("project");
                });

            modelBuilder.Entity("CrudRepositoryExample.Data.Model.ProjectRoleModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ProjectId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("project_role");
                });

            modelBuilder.Entity("CrudRepositoryExample.Data.Model.ToDoModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ProjectId");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ToDo");
                });

            modelBuilder.Entity("CrudRepositoryExample.Data.Model.UserModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("CrudRepositoryExample.Data.Model.ProjectRoleModel", b =>
                {
                    b.HasOne("CrudRepositoryExample.Data.Model.ProjectModel", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrudRepositoryExample.Data.Model.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CrudRepositoryExample.Data.Model.ToDoModel", b =>
                {
                    b.HasOne("CrudRepositoryExample.Data.Model.ProjectModel", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
