﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pratical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.DAL.Entities;

namespace Pratical.DAL
{
    public class DBContainer: IdentityDbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Employe> Employee { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        public DBContainer(DbContextOptions<DBContainer> dpt) :base(dpt)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server = . ; database = SharpDb ; integrated security = true");
        //}
    }
}
