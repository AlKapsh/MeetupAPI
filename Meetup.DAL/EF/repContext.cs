using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Meetup.DAL.EF {
    internal class repContext: DbContext {
        string? connectionStr;
        public repContext(DbContextOptions<repContext> options) : base(options) {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: true, reloadOnChange: true);

            IConfiguration config = builder.Build();

            this.connectionStr = config.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(connectionStr);
        }
    }
}
