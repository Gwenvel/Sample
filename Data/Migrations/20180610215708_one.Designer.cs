﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace test2.Data.Migrations
{
    [DbContext(typeof(RequestContext))]
    [Migration("20180610215708_one")]
    partial class one
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("test2.Models.Departments", b =>
                {
                    b.Property<int>("DepartmentsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department");

                    b.HasKey("DepartmentsId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("test2.Models.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Closed");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Department");

                    b.Property<bool>("InProgress");

                    b.Property<bool>("Pending");

                    b.Property<bool>("Urgent");

                    b.Property<string>("User");

                    b.Property<string>("WorkRequest");

                    b.HasKey("RequestId");

                    b.ToTable("Request");
                });
#pragma warning restore 612, 618
        }
    }
}
