
using FluentValidation;

namespace Employee_System.Validators
{
    public class LoginRequestValidator: AbstractValidator<DTO.LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
