using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DariaVarya.Web.App.Models;

namespace DariaVarya.Web.App.Data
{
    public class DariaVaryaWebAppContext : DbContext
    {
        public DariaVaryaWebAppContext (DbContextOptions<DariaVaryaWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<ChangeControl> ChangeControl { get; set; } = default!;
        public DbSet<Approval> Approval { get; set; } = default!;
        public DbSet<UserModel> User { get; set; } = default!;
        public DbSet<UserProfileModel> UserProfiles { get; set; } = default!;
        public DbSet<Department> Departments { get; set; } = default!;
    }
}
