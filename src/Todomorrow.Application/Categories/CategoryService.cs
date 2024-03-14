using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todomorrow.Domain.Categories;
using Todomorrow.Domain.Notifications;

namespace Todomorrow.Application.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly INotificationContext  _notificationContext;

        public CategoryService(ICategoryRepository categoryRepository, INotificationContext notificationContext)
        {
            _categoryRepository = categoryRepository;
            _notificationContext = notificationContext;
        }

        public async Task<Category> Create(Category category)
        {
            return await _categoryRepository.Create(category);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        private async Task<Category> ValidateCategoryById(Guid categoryId)
        {
            Category category = await _categoryRepository.GetById(categoryId);
            if (category is null)
            {
                _notificationContext.AddNotFoundError(CategoryError.CATEGORY_NOT_FOUND);
            }

            return category;
        }

        public async Task<Category> GetById(Guid categoryId)
        {
            Category category = await ValidateCategoryById(categoryId);
            if (category is null)
            {
                return null;
            }

            return category;
        }

        public async Task<Category> Update(Category category)
        {
            Category categoryRegistered = await ValidateCategoryById(category.Id);
            if (category is null)
            {
                return null;
            }

            categoryRegistered.Name = category.Name;

            return await _categoryRepository.Update(categoryRegistered);
        }
    }
}
