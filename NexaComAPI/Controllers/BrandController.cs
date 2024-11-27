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
    public class BrandController : ControllerBase
    {
        private readonly IBrandBusiness _BrandBusiness;

        public BrandController(IBrandBusiness BrandBusiness)
        {
            _BrandBusiness = BrandBusiness;
        }

        [HttpGet]
        [Route("GetAllBrands")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllBrands()
        {
            var Brands = await _BrandBusiness.GetAllBrandsAsync();
            return Ok(Brands);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetBrandById")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var Brand = await _BrandBusiness.GetBrandByIdAsync(id);
            if (Brand == null)
            {
                return NotFound();
            }
            return Ok(Brand);
        }

        [HttpPost]
        [Route("Create")]
        //api/user/create
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateBrand([FromBody] BrandModel BrandDto)
        {
            var result = await _BrandBusiness.CreateBrandAsync(BrandDto);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetBrandById), new { id = BrandDto.BrandId }, BrandDto);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateBrand")]
        //api/student/update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateBrand(int id, [FromBody]BrandModel BrandDto)
        {
            if (id != BrandDto.BrandId)
            {
                return BadRequest();
            }

            var result = await _BrandBusiness.UpdateBrandAsync(BrandDto);
            if (result != null)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var result = await _BrandBusiness.DeleteBrandAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
