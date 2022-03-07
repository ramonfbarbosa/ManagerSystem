using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("The entity cant be empty.")

                .NotNull()
                .WithMessage("The entity cant be empty.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("The name cant be empty.")

                .NotNull()
                .WithMessage("The name cant be empty.")

                .MinimumLength(3)
                .WithMessage("The name must be at least 3 characters.")

                .MaximumLength(80)
                .WithMessage("The name mustn't exceed 80 characters.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("The email mustn't be empty.")

                .NotNull()
                .WithMessage("The email cant be empty.")

                .MinimumLength(10)
                .WithMessage("The email must be at least 10 characters.")

                .MaximumLength(180)
                .WithMessage("The email mustn't be exceed 180 characters.")
                
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("The email must be valid.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("The password cant be empty.")

                .NotNull()
                .WithMessage("The password cant be empty.")

                .MinimumLength(6)
                .WithMessage("The password must be at least 6 characters.")

                .MaximumLength(30)
                .WithMessage("The password mustn't be 80 exceed 30 characters.");
        }
    }
}
