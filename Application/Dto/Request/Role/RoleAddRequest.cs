using FluentValidation;

namespace Dto.Request.Role
{
    public class RoleAddRequest
    {
        public string roleName { get; set; } = string.Empty;
    }

    public class RoleAddRequestValidator : AbstractValidator<RoleAddRequest>
    {
        public RoleAddRequestValidator()
        {
            RuleFor(x => x.roleName)
                .NotNull().NotEmpty().WithMessage("Ad gereklidir.")
                .MaximumLength(50).WithMessage("Ad 50 karakteri geçmemelidir.");
        }
    }
}
