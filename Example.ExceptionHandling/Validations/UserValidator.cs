using Example.ExceptionHandling.Models;
using FluentValidation;

namespace Example.ExceptionHandling.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(pUser => pUser.Username).NotEmpty().Length(5, 20);
            RuleFor(pUser => pUser.FirstName).NotEmpty().Length(1, 50);
            RuleFor(pUser => pUser.LastName).NotEmpty().Length(1, 50);
            RuleFor(pUser => pUser.DateOfBirth).LessThan(DateTime.Today);
        }
    }
}