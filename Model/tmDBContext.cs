using System.Data.Entity;

namespace Tasks.Model
//namespace PDBProject.Model
{
    class tmDBContext:DbContext
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
