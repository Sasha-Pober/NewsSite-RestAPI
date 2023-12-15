using BLL.DTO;
using FluentValidation;

namespace BLL.Validators;

public class AuthorValidator : AbstractValidator<AuthorDTO>
{
    public AuthorValidator()
    {
        RuleFor(x => x.Email).EmailAddress().WithMessage("Check your email!");
        RuleFor(x => x.Password).Length(8);
    }
}
