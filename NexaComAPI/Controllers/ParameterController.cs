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
    public class ParameterController : ControllerBase
    {
        private readonly IParameterBusiness _ParameterBusiness;

        public ParameterController(IParameterBusiness ParameterBusiness)
        {
            _ParameterBusiness = ParameterBusiness;
        }

        [HttpGet]
        [Route("GetAllParameters")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllParameters()
        {
            var Parameters = await _ParameterBusiness.GetAllParametersAsync();
            return Ok(Parameters);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetParameterById")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetParameterById(int id)
        {
            var Parameter = await _ParameterBusiness.GetParameterByIdAsync(id);
            if (Parameter == null)
            {
                return NotFound();
            }
            return Ok(Parameter);
        }

        [HttpPost]
        [Route("Create")]
        //api/user/create
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateParameter([FromBody] ParameterModel ParameterDto)
        {
            var result = await _ParameterBusiness.CreateParameterAsync(ParameterDto);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetParameterById), new { id = ParameterDto.ParameterId }, ParameterDto);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateParameter")]
        //api/student/update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateParameter(int id, [FromBody] ParameterModel ParameterDto)
        {
            if (id != ParameterDto.ParameterId)
            {
                return BadRequest();
            }

            var result = await _ParameterBusiness.UpdateParameterAsync(ParameterDto);
            if (result != null)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParameter(int id)
        {
            var result = await _ParameterBusiness.DeleteParameterAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
