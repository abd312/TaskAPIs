using System.Collections.Generic;
using TaskApis.Entities;
using Microsoft.EntityFrameworkCore;

namespace TaskApis.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
    }
}
