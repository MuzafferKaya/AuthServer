using FluentValidation;

namespace Dto.Request.User
{
    public class UserUpdateRequest
    {
        public string userName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public long roleId { get; set; }
    }

    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator()
        {
            RuleFor(x => x.userName)
                .NotNull().NotEmpty().WithMessage("Kullanıcı adı gereklidir.")
                .MaximumLength(50).WithMessage("Kullanıcı adı 50 karakteri geçmemelidir.");
            RuleFor(x => x.email)
                .NotNull().NotEmpty().WithMessage("E-posta gereklidir.")
                .MaximumLength(50).WithMessage("E-posta 50 karakteri geçmemelidir.")
                .EmailAddress().WithMessage("Geçerli bir e-posta gereklidir.");
            RuleFor(x => x.phoneNumber)
                .NotNull().NotEmpty().WithMessage("Telefon numarası gereklidir.")
                .MinimumLength(10).WithMessage("Telefon numarası 10 karakterden az olmamalıdır.")
                .MaximumLength(11).WithMessage("Telefon numarası 11 karakteri geçmemelidir.");
            RuleFor(x => x.password)
                .NotNull().NotEmpty().WithMessage("Şifre gereklidir.")
                .MinimumLength(8).WithMessage("Şifre 8 karakterden az olmamalıdır.")
                .MaximumLength(50).WithMessage("Şifre 50 karakteri geçmemelidir.");
            RuleFor(x => x.roleId)
                .NotNull().NotEmpty().WithMessage("Role id gereklidir.");
        }
    }
}
