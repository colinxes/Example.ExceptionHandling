namespace Example.ExceptionHandling.Requests
{
    public class CreateUserRequest
    {
        public string Username { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string RequestingUsername { get; set; } = string.Empty;
    }
}