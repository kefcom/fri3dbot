using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data
{
    public class FaceRequestContext : DbContext
    {
        public DbSet<FaceRequest> FaceRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=blogging.db");
        }
    }
}