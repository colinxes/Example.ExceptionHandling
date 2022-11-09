namespace Example.ExceptionHandling.Exceptions
{
    public class UnknownUserException : Exception
    {
        public string Username { get; }

        public UnknownUserException(string? pMessage, string pUsername) : base(pMessage)
        {
            Username = pUsername;
        }

        public UnknownUserException(string pMessage, Exception pInnerException, string pUsername) : base(pMessage, pInnerException)
        {
            Username = pUsername;
        }
    }
}