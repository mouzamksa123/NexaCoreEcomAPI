using App.ApplicationLayer.Interface;
using App.CommonLayer.DTOModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NexaComAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryBusiness _CategoryBusiness;

        public CategoryController(ICategoryBusiness CategoryBusiness)
        {
            _CategoryBusiness = CategoryBusiness;
        }

        [HttpGet]
        [Route("GetAllCategorys")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllCategorys()
        {
            var Categorys = await _CategoryBusiness.GetAllCategorysAsync();
            return Ok(Categorys);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetCategoryById")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var Category = await _CategoryBusiness.GetCategoryByIdAsync(id);
            if (Category == null)
            {
                return NotFound();
            }
            return Ok(Category);
        }

        [HttpPost]
        [Route("Create")]
        //api/user/create
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateCategory([FromBody] CateogryModel CategoryDto)
        {
            var result = await _CategoryBusiness.CreateCategoryAsync(CategoryDto);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetCategoryById), new { id = CategoryDto.CategoryId }, CategoryDto);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateCategory")]
        //api/student/update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CateogryModel CategoryDto)
        {
            if (id != CategoryDto.CategoryId)
            {
                return BadRequest();
            }

            var result = await _CategoryBusiness.UpdateCategoryAsync(CategoryDto);
            if (result != null)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _CategoryBusiness.DeleteCategoryAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
