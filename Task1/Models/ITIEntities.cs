using Microsoft.EntityFrameworkCore;

namespace Task1.Models
{
    public class ITIEntities:DbContext
    {
        public ITIEntities() { }
        public ITIEntities(DbContextOptions options):base(options) { }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<teamMember> TeamMembers { get; set; }
    }
}
