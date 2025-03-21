using Microsoft.EntityFrameworkCore;

namespace CloudDbExample
{
    public class ApplicationDbContext : DbContext
    {
        public required DbSet<Copybook> Copybooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"
                Host=aws-0-eu-central-1.pooler.supabase.com;
                Database=postgres;
                Username=postgres.hsmrmvwkrvujhqekkmht;
                Password=postgres;
            ";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
