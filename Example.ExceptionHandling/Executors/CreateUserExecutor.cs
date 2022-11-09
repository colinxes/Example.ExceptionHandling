using Example.ExceptionHandling.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace Example.ExceptionHandling.Executors
{
    public class CreateUserExecutor
    {
        public CreateUserExecutor Try(Action? pAction)
        {
            try
            {
                pAction?.Invoke();
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The given user request cannot be empty!");
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Timeout while trying to access the database. Pleas try it again!");
            }
            catch (ValidationException validationException)
            {
                string errorCaption = $"Invalid input! Please correct the following values: {Environment.NewLine}";
                string aggregatedMessage = AggregateValidationFailures(errorCaption, validationException.Errors); 
                Console.WriteLine(aggregatedMessage);
            }
            catch (UnknownUserException unknownUserException)
            {
                Console.WriteLine($"The requesting user \"{unknownUserException.Username}\" is unknown!");
            }
            catch (InvalidUserException invalidUserException)
            {
                string errorCaption = $"Invalid user! Please check the following problems: {Environment.NewLine}";
                string aggregatedMessage = AggregateValidationFailures(errorCaption, invalidUserException.Errors); 
                Console.WriteLine(aggregatedMessage);
            }

            return this;
        }

        private static string AggregateValidationFailures(string pErrorCaption, IEnumerable<ValidationFailure> pValidationFailures)
        {
            return pValidationFailures.Aggregate(pErrorCaption, (pCurrent, pError) => pCurrent + $"{pError} {Environment.NewLine}");
        }
    }
}