using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todomorrow.Domain.Notifications;
using Todomorrow.Domain.UserSkills;

namespace Todomorrow.Application.UserSkills
{
    public class UserSkillService : IUserSkillService
    {
        private readonly IUserSkillRepository _userSkillRepository;
        private readonly INotificationContext _notificationContext;

        public UserSkillService(IUserSkillRepository userSkillRepository, INotificationContext notificationContext)
        {
            _userSkillRepository = userSkillRepository;
            _notificationContext = notificationContext;
        }

        public async Task<UserSkill> Create(UserSkill userSkill)
        {
            return await _userSkillRepository.Create(userSkill);
        }

        private async Task<UserSkill> ValidateUserSkill(Guid userSkillId)
        {
            UserSkill userSkill = await _userSkillRepository.GetById(userSkillId);
            if (userSkill == null)
            {
                _notificationContext.AddValidationError(UserSkillError.USER_SKILL_NOT_FOUND);
                return null;
            }

            return userSkill;
        }

        public Task<IEnumerable<UserSkill>> GetAllByLoggedUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserSkill> GetById(Guid userSkillId)
        {
            UserSkill userSkill = await ValidateUserSkill(userSkillId);
            if (userSkill is null)
            {
                return null;
            }

            return userSkill;
        }

        public async Task<UserSkill> Update(UserSkill userSkill)
        {
            UserSkill userSkillRegistered = await ValidateUserSkill(userSkill.Id);
            if (userSkill is null)
            {
                return null;
            }

            userSkillRegistered.Level = userSkill.Level;

            return await _userSkillRepository.Update(userSkillRegistered);
        }
    }
}
