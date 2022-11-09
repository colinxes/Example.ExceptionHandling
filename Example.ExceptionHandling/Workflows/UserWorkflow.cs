using Example.ExceptionHandling.Exceptions;
using Example.ExceptionHandling.Manager;
using Example.ExceptionHandling.Models;
using Example.ExceptionHandling.Requests;
using Example.ExceptionHandling.Validations;
using FluentValidation;

namespace Example.ExceptionHandling.Workflows
{
    public class UserWorkflow
    {
        private readonly UserManager _userManager;
        private readonly UserValidator _userValidator;

        public UserWorkflow()
        {
            _userManager = new UserManager();
            _userValidator = new UserValidator();
        }

        public void CreateUser(CreateUserRequest? pRequest)
        {
            if (pRequest is null)
                throw new ArgumentNullException(nameof(pRequest));
                
            User? requestingUser = _userManager.GetUserByUsername(pRequest.RequestingUsername);

            if (requestingUser is null)
                throw new UnknownUserException($"User with username \"{pRequest.RequestingUsername}\" does not exist!", pRequest.RequestingUsername);
            
            
            User user = new()
            {
                Username = pRequest.Username,
                CreatedBy = requestingUser.Id,
                FirstName = pRequest.FirstName,
                LastName = pRequest.LastName,
                DateOfBirth = pRequest.DateOfBirth
            };
            
            _userValidator.ValidateAndThrow(user);
            _userManager.CreateUser(user);
        }
    }
}