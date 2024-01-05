using Dto.Request.Authentication;
using Dto.Request.Customer;
using Dto.Request.Role;
using Dto.Request.User;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dto.Extensions
{
    public static class DtoExtensions
    {
        public static IServiceCollection LoadDtoExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CustomerAddRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<CustomerUpdateRequestValidator>();

            services.AddValidatorsFromAssemblyContaining<UserAddRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<UserUpdateRequestValidator>();

            services.AddValidatorsFromAssemblyContaining<AuthenticationLoginRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<RoleAddRequestValidator>();            

            return services;
        }
    }
}
