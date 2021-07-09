using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NewsPortal.Models
{
    public class ModelsContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ModelsContext(DbContextOptions<ModelsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
