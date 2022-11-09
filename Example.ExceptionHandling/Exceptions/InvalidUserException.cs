using FluentValidation.Results;

namespace Example.ExceptionHandling.Exceptions
{
    public class InvalidUserException : Exception
    {
        public IEnumerable<ValidationFailure> Errors { get; }

        public InvalidUserException(string pMessage,  IEnumerable<ValidationFailure> pValidationFailures) : base(pMessage)
        {
            Errors = pValidationFailures;
        }

        public InvalidUserException(string pMessage, Exception pInnerException,  IEnumerable<ValidationFailure> pValidationFailures) : base(pMessage, pInnerException)
        {
            Errors = pValidationFailures;
        }
    }
}