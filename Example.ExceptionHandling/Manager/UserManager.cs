using Example.ExceptionHandling.Exceptions;
using Example.ExceptionHandling.Models;
using Example.ExceptionHandling.Repositories;
using FluentValidation;
using FluentValidation.Results;

namespace Example.ExceptionHandling.Manager
{
    public class UserManager
    {
        private readonly UserRepository _userRepository;

        public UserManager()
        {
            _userRepository = new UserRepository();
        }

        public void CreateUser(User pUser)
        {
            List<ValidationFailure> validationFailures = new();
            
            if (_userRepository.ExistsWithId(pUser.Id))
            {
                const string message = "A user with same id already exists";
                validationFailures.Add(new ValidationFailure(nameof(User), message));
            }
            
            if (_userRepository.ExistsWithUsername(pUser.Username))
            {
                const string message = "A user with same usernmae already exists";
                validationFailures.Add(new ValidationFailure(nameof(User), message));
            }
            
            if (validationFailures.Any()) 
                throw new InvalidUserException("User already exists!", validationFailures);
            
            _userRepository.CreateUser(pUser);
        }

        public User? GetUserByUsername(string pUsername)
        {
            return _userRepository.GetByUsername(pUsername);
        }
    }
}