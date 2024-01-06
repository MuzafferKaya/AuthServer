using FluentValidation;

namespace Dto.Request.Role
{
    public class RoleUpdateRequest
    {
        public long id { get; set; }
        public string roleName { get; set; } = string.Empty;
    }

    public class RoleUpdateRequestValidator : AbstractValidator<RoleUpdateRequest>
    {
        public RoleUpdateRequestValidator()
        {
            RuleFor(x => x.id)
                .NotNull().NotEmpty().WithMessage("Id gereklidir.");
            RuleFor(x => x.roleName)
                .NotNull().NotEmpty().WithMessage("Ad gereklidir.")
                .MaximumLength(50).WithMessage("Ad 50 karakteri geçmemelidir.");
        }
    }
}
