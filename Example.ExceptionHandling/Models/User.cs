using Example.ExceptionHandling.Models.Base;

namespace Example.ExceptionHandling.Models
{
    public class User : EntityBase
    {
        public string Username { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }
    }
}