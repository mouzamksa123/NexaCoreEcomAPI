using App.ApplicationLayer.Interface;
using App.CommonLayer.DTOModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NexaComAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRoleBusiness _RoleBusiness;

        public RoleController(IRoleBusiness RoleBusiness)
        {
            _RoleBusiness = RoleBusiness;
        }

        [HttpGet]
        [Route("GetAllRoles")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllRoles()
        {
            var Roles = await _RoleBusiness.GetAllRolesAsync();
            return Ok(Roles);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetRoleById")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var Role = await _RoleBusiness.GetRoleByIdAsync(id);
            if (Role == null)
            {
                return NotFound();
            }
            return Ok(Role);
        }

        [HttpPost]
        [Route("Create")]
        //api/user/create
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateRole([FromBody] RoleModel RoleDto)
        {
            var result = await _RoleBusiness.CreateRoleAsync(RoleDto);
            if (result != null)
            {
                return CreatedAtAction(nameof(GetRoleById), new { id = RoleDto.RoleId }, RoleDto);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateRole")]
        //api/student/update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] RoleModel RoleDto)
        {
            if (id != RoleDto.RoleId)
            {
                return BadRequest();
            }

            var result = await _RoleBusiness.UpdateRoleAsync(RoleDto);
            if (result != null)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _RoleBusiness.DeleteRoleAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
