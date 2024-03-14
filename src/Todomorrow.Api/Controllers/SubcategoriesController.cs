using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Todomorrow.Contracts.Subcategories;
using Todomorrow.Domain.Subcategories;

namespace Todomorrow.Api.Controllers
{
    [Route("api/v1/subcategories")]
    [Authorize]
    public class SubcategoriesController : Controller
    {
        private readonly ISubcategoryService _subcategoryService;
        private readonly IMapper _mapper;

        public SubcategoriesController(ISubcategoryService subcategoryService, IMapper mapper)
        {
            _subcategoryService = subcategoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new subcategory
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(SubcategoryResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateSubcategoryRequest request)
        {
            Subcategory subcategory = _mapper.Map<Subcategory>(request);
            subcategory = await _subcategoryService.Create(subcategory);

            return Created($"api/v1/subcategories/{subcategory.Id}", subcategory is not null ? _mapper.Map<SubcategoryResponse>(subcategory) : null);
        }

        /// <summary>
        /// Get all subcategories for a category
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("{categoryId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<SubcategoryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] Guid categoryId)
        {
            IEnumerable<Subcategory >subcategories = await _subcategoryService.GetAllByCategoryId(categoryId);

            return Ok(_mapper.Map<IEnumerable<SubcategoryResponse>>(subcategories));
        }
    }
}
