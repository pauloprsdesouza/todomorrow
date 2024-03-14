using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todomorrow.Domain.Notifications;
using Todomorrow.Domain.Subcategories;

namespace Todomorrow.Application.Subcategories
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly INotificationContext _notificationContext;

        public SubcategoryService(ISubcategoryRepository subcategoryRepository, INotificationContext notificationContext)
        {
            _subcategoryRepository = subcategoryRepository;
            _notificationContext = notificationContext;
        }

        public async Task<Subcategory> Create(Subcategory subcategory)
        {
            return await _subcategoryRepository.Create(subcategory);
        }

        private async Task<Subcategory> ValidateSubcategoryById(Guid subcategoryId)
        {
            Subcategory subcategory = await _subcategoryRepository.GetById(subcategoryId);
            if (subcategory == null)
            {
                _notificationContext.AddValidationError(SubcategoryError.SUBCATEGORY_NOT_FOUND);
                return null;
            }

            return subcategory;
        }

        public async Task<IEnumerable<Subcategory>> GetAllByCategoryId(Guid categoryId)
        {
            return await _subcategoryRepository.GetAllByCategoryId(categoryId);
        }

        public async Task<Subcategory> Update(Subcategory subcategory)
        {
            Subcategory subcategoryRegistered = await ValidateSubcategoryById(subcategory.Id);
            if (subcategory is null)
            {
                return null;
            }

            subcategoryRegistered.Name = subcategory.Name;
            subcategoryRegistered.Description = subcategory.Description;

            return await _subcategoryRepository.Update(subcategory);
        }
    }
}
