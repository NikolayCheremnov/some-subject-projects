using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DockerizedAppExampleWithDb
{
    // Customer - покупатель, зарегистрированный в бонусной программе магазина
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class Customer
    {
        public int Id { get; set; }
        [MinLength(1)]
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly RegisteredAt { get; set; }
        public DateOnly BirthDate { get; set; }

        public Customer() { }
    }
}
