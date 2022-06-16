using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Entity;

namespace TaskApp.Data.Concrete.EF
{
    public class TaskAppContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Entity.Task> Tasks { get; set; }
        public DbSet<TaskAssignment> TaskAssignments { get; set; }
        public DbSet<TaskWithDocument> TaskWithDocuments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TaskApp");
        }
    }
}
