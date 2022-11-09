using Example.ExceptionHandling.Models;

namespace Example.ExceptionHandling.Database
{
    public class UserTable
    {
        private const string ADMINISTRATOR_ID = "2f1f94b4-7516-4688-b103-e8e8a824b1ba";
        private static UserTable? _instance;
        public static UserTable Instance => _instance ??= new UserTable();

        public List<User> Data { get; } = new()
        {
            new User
            {
                Id = Guid.Parse(ADMINISTRATOR_ID),
                Username = "Administrator",
                CreatedBy = Guid.Parse(ADMINISTRATOR_ID),
                FirstName = "System",
                LastName = "Administrator",
                EditedAt = DateTime.Now,
                EditedBy = Guid.Parse(ADMINISTRATOR_ID),
                DateOfBirth = new DateTime(1900, 1, 1)
            }
        };
        
        private UserTable() { /* Singleton */ }
    }
}