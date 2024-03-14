using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Todomorrow.Contracts.Categories;
using Todomorrow.Domain.Categories;

namespace Todomorrow.Api.Controllers
{
    [Route("api/v1/categories")]
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new category
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            Category category = _mapper.Map<Category>(request);
            category = await _categoryService.Create(category);

            return Created($"api/v1/categories/{category.Id}", category is not null ? _mapper.Map<CategoryResponse>(category) : null);
        }

        /// <summary>
        /// Update a registered category
        /// </summary>
        /// <returns></returns>
        [HttpPut, Route("{categoryId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] Guid categoryId, [FromBody] UpdateCategoryRequest request)
        {
            Category category = _mapper.Map<Category>(request);
            category.Id = categoryId;

            category = await _categoryService.Update(category);

            return Ok(category is not null ? _mapper.Map<CategoryResponse>(category) : null);
        }

        /// <summary>
        /// Get all registered categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Category> categories = await _categoryService.GetAll();

            return Ok(_mapper.Map<IEnumerable<CategoryResponse>>(categories));
        }
    }
}
