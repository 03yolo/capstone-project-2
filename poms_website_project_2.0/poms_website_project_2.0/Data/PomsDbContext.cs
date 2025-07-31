using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using poms_website_project_2._0.Models;

    public class PomsDbContext : DbContext
    {
        public PomsDbContext (DbContextOptions<PomsDbContext> options)
            : base(options)
        {
        }

        public DbSet<poms_website_project_2._0.Models.UserModel> UserModel { get; set; } = default!;
    }
