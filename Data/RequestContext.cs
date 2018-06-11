using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test2.Data;
using test2.Models;

public class RequestContext : DbContext
    {
        public RequestContext (DbContextOptions<RequestContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Request { get; set; }
        public DbSet<Departments> Departments { get; set; }
    }
