using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage
{
    public class TrainerDBContext : DbContext
    {
        public TrainerDBContext(DbContextOptions<TrainerDBContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
