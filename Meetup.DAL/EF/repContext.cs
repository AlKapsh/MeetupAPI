using Meetup.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Meetup.DAL.EF {
    public class repContext: IdentityDbContext<User> {
        public DbSet<MeetEvent> Events { get; set; }
        public repContext(DbContextOptions options) : base(options) {

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}
