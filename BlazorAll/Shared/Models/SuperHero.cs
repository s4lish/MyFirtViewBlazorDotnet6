using System.ComponentModel.DataAnnotations;

namespace BlazorAll.Shared.Models
{
    public class SuperHero
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string HeroName { get; set; } = string.Empty;
    }
}
