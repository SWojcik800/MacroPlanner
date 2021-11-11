using IdentityServer4.EntityFramework.Options;
using MacroPlanner.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MacroPlanner.Entity;

namespace MacroPlanner.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Entity.Board> Boards { get; set; }
        public DbSet<Entity.BoardTask> Tasks{ get; set; }
        public DbSet<BoardMembers> BoardMembers { get; set; }
    }
}
