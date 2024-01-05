using FluentValidation;

namespace Dto.Request.Authentication
{
    public class AuthenticationRequest
    {
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }

    public class AuthenticationLoginRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationLoginRequestValidator()
        {
            RuleFor(x => x.email)
                .NotNull().NotEmpty().WithMessage("E-posta gereklidir.")
                .MaximumLength(50).WithMessage("E-posta 50 karakteri geçmemelidir.")
                .EmailAddress().WithMessage("Geçerli bir e-posta gereklidir.");
            RuleFor(x => x.password)
                .NotNull().NotEmpty().WithMessage("Şifre gereklidir.")
                .MinimumLength(8).WithMessage("Şifre 8 karakterden az olmamalıdır.")
                .MaximumLength(50).WithMessage("Şifre 50 karakteri geçmemelidir.");
        }
    }
}
