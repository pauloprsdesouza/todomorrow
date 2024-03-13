using AutoMapper;
using Todomorrow.Contracts.Users;
using Todomorrow.Domain.Users;

namespace Todomorrow.Infrastructure.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignInRequest, User>();

            CreateMap<SignUpRequest, User>();

            CreateMap<User, UserResponse>();
        }
    }
}
