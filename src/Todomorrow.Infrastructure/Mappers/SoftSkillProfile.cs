using AutoMapper;
using Todomorrow.Contracts.SoftSkills;
using Todomorrow.Domain.SoftSkills;

namespace Todomorrow.Infrastructure.Mappers
{
    public class SoftSkillProfile : Profile
    {
        public SoftSkillProfile()
        {
            CreateMap<SoftSkill, SoftSkillResponse>();
            CreateMap<CreateSoftSkillRequest, SoftSkill>();
            CreateMap<UpdateSoftSkillRequest, SoftSkill>();
        }
    }
}
