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
    public class ParameterTypeController : ControllerBase
    {
        private readonly IParameterTypeBusiness _ParameterTypeBusiness;

        public ParameterTypeController(IParameterTypeBusiness ParameterTypeBusiness)
        {
            _ParameterTypeBusiness = ParameterTypeBusiness;
        }

        [HttpGet]
        [Route("GetAllParameterTypes")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllParameterTypes()
        {
            var ParameterTypes = await _ParameterTypeBusiness.GetAllParameterTypesAsync();
            return Ok(ParameterTypes);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetParameterTypeById")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetParameterTypeById(int id)
        {
            var ParameterType = await _ParameterTypeBusiness.GetParameterTypeByIdAsync(id);
            if (ParameterType == null)
            {
                return NotFound();
            }
            return Ok(ParameterType);
        }

        [HttpPost]
        [Route("Create")]
        //api/user/create
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateParameterType([FromBody] ParameterTypeModel ParameterTypeDto)
        {
            var result = await _ParameterTypeBusiness.CreateParameterTypeAsync(ParameterTypeDto);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetParameterTypeById), new { id = ParameterTypeDto.ParameterTypeId }, ParameterTypeDto);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateParameterType")]
        //api/student/update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateParameterType(int id, [FromBody] ParameterTypeModel ParameterTypeDto)
        {
            if (id != ParameterTypeDto.ParameterTypeId)
            {
                return BadRequest();
            }

            var result = await _ParameterTypeBusiness.UpdateParameterTypeAsync(ParameterTypeDto);
            if (result != null)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParameterType(int id)
        {
            var result = await _ParameterTypeBusiness.DeleteParameterTypeAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
