using FluentValidation;

namespace Dto.Request.Customer
{
    public class CustomerAddRequest
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string passwordHash { get; set; } = string.Empty;
        public string address1 { get; set; } = string.Empty;
        public string address2 { get; set; } = string.Empty;
        public string postalCode { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
    }

    public class CustomerAddRequestValidator : AbstractValidator<CustomerAddRequest>
    {
        public CustomerAddRequestValidator()
        {
            RuleFor(x => x.firstName)
                .NotNull().NotEmpty().WithMessage("Ad gereklidir.")
                .MaximumLength(50).WithMessage("Ad 50 karakteri geçmemelidir.");
            RuleFor(x => x.lastName)
                .NotNull().NotEmpty().WithMessage("Soyad gereklidir.")
                .MaximumLength(50).WithMessage("Soyad 50 karakteri geçmemelidir.");
            RuleFor(x => x.phoneNumber)
                .NotNull().NotEmpty().WithMessage("Telefon numarası gereklidir.")
                .MinimumLength(10).WithMessage("Telefon numarası 10 karakterden az olmamalıdır.")
                .MaximumLength(11).WithMessage("Telefon numarası 11 karakteri geçmemelidir.");
            RuleFor(x => x.email)
                .NotNull().NotEmpty().WithMessage("E-posta gereklidir.")
                .MaximumLength(50).WithMessage("E-posta 50 karakteri geçmemelidir.")
                .EmailAddress().WithMessage("Geçerli bir e-posta gereklidir.");
            RuleFor(x => x.passwordHash)
                .NotNull().NotEmpty().WithMessage("Şifre gereklidir.")
                .MinimumLength(8).WithMessage("Şifre 8 karakterden az olmamalıdır.")
                .MaximumLength(50).WithMessage("Şifre 50 karakteri geçmemelidir.");
            RuleFor(x => x.address1)
                .MaximumLength(50).WithMessage("Adres bir 50 karakteri geçmemelidir.");
            RuleFor(x => x.address2)
                .MaximumLength(50).WithMessage("Adres iki 50 karakteri geçmemelidir.");
            RuleFor(x => x.postalCode)
                .MaximumLength(50).WithMessage("Posta Kodu 50 karakteri geçmemelidir.");
            RuleFor(x => x.country)
                .MaximumLength(50).WithMessage("Ülke 50 karakteri geçmemelidir.");
            RuleFor(x => x.city)
                .MaximumLength(50).WithMessage("Şehir 50 karakteri geçmemelidir.");
        }
    }
}
