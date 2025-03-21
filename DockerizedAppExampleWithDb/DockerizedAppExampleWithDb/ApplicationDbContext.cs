using Microsoft.EntityFrameworkCore;

namespace DockerizedAppExampleWithDb
{
    public class ApplicationDbContext : DbContext
    {
        public required DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            string useConnection = config.GetSection("UseConnection").Value ?? "DefaultConnection";
            string? connectionString = config.GetConnectionString(useConnection);
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
