using Microsoft.EntityFrameworkCore;

namespace RequestGrabberApiApp
{
    public class ApplicationDbContext : DbContext 
    {
        public required DbSet<Request> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            string useConnection = config["useConnection"] ?? "DefaultConnection";
            string? connectionString = config.GetConnectionString(useConnection);
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
