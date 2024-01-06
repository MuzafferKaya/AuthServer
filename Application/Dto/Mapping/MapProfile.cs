using AutoMapper;
using DomainModel.Entities;
using Dto.Request.Customer;
using Dto.Request.Role;
using Dto.Request.User;
using Dto.Response.Customer;
using Dto.Response.Role;
using Dto.Response.User;

namespace Dto.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<CustomerAddRequest, Customer>();
            CreateMap<CustomerUpdateRequest, Customer>();
            CreateMap<Customer, CustomerGetAllResponse>();
            CreateMap<Customer, CustomerGetByIdResponse>();

            CreateMap<UserAddRequest, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.password));
            CreateMap<UserUpdateRequest, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.password));
            CreateMap<User, UserGetAllResponse>();

            CreateMap<RoleAddRequest, Role>();
            CreateMap<RoleUpdateRequest, Role>();
            CreateMap<Role, RoleGetAllResponse>();
        }
    }
}
