using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todomorrow.Domain.Notifications;
using Todomorrow.Domain.SoftSkills;
using Todomorrow.Domain.Subcategories;

namespace Todomorrow.Application.SoftSkills
{
    public class SoftSkillService : ISoftSkillService
    {
        private readonly ISoftSkillRepository _softSkillRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly INotificationContext _notificationContext;

        public SoftSkillService(ISoftSkillRepository softSkillRepository, ISubcategoryRepository subcategoryRepository, INotificationContext notificationContext)
        {
            _softSkillRepository = softSkillRepository;
            _subcategoryRepository = subcategoryRepository;
            _notificationContext = notificationContext;
        }

        public async Task<SoftSkill> Create(SoftSkill softSkill)
        {
            return await _softSkillRepository.Create(softSkill);
        }

        public Task<IEnumerable<SoftSkill>> GetAllBySubcategoryId(Guid subcategoryId)
        {
            return _softSkillRepository.GetAllBySubcategoryId(subcategoryId);
        }

        private async Task<SoftSkill> ValidateSoftSkillById(Guid softSkillId)
        {
            SoftSkill softSkill = await _softSkillRepository.GetById(softSkillId);

            if (softSkill is null)
            {
                _notificationContext.AddValidationError(SoftSkillError.SOFT_SKILL_NOT_FOUND);
            }

            return softSkill;
        }

        public async Task<SoftSkill> GetById(Guid softSkillId)
        {
            SoftSkill softSkill = await ValidateSoftSkillById(softSkillId);
            if(softSkill is null)
            {
                return null;
            }

            return softSkill;
        }

        public async Task<SoftSkill> Update(SoftSkill softSkill)
        {
            SoftSkill softSkillRegistered = await ValidateSoftSkillById(softSkill.Id);
            if (softSkill is null)
            {
                return null;
            }

            softSkillRegistered.Name = softSkill.Name;
            softSkillRegistered.SubcategoryId = softSkill.SubcategoryId;

            return await _softSkillRepository.Update(softSkillRegistered);
        }
    }
}
