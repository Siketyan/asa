using Asa.Models;
using Asa.Models.Activity;
using Microsoft.EntityFrameworkCore;

namespace Asa.DbContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Directory> Directories { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Line> Lines { get; set; }
        
        public DbSet<Insertion> Insertions { get; set; }
        public DbSet<Modification> Modifications { get; set; }
        public DbSet<Deletion> Deletions { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
