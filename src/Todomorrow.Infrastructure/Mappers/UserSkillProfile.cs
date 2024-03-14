using AutoMapper;
using Todomorrow.Contracts.UserSkills;
using Todomorrow.Domain.UserSkills;

namespace Todomorrow.Infrastructure.Mappers
{
    public class UserSkillProfile : Profile
    {
        public UserSkillProfile()
        {
            CreateMap<UserSkill, UserSkillResponse>();
            CreateMap<CreateUserSkillRequest, UserSkill>();
            CreateMap<UpdateUserSkillRequest, UserSkill>();
        }
    }
}
