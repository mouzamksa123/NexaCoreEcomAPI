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
    public class ProductController : ControllerBase
    {
        private readonly IProductBusiness _productBusiness;

        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productBusiness.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetProductById")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productBusiness.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
 
        [HttpPost]
        [Route("Create")]
        //api/user/create
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel productDto)
        {
            var result = await _productBusiness.CreateProductAsync(productDto);
            if (result!=null)
            {
                return CreatedAtAction(nameof(GetProductById), new { id = productDto.ProductId }, productDto);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("UpdateProduct")]
        //api/student/update
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody]ProductModel productDto)
        {
            if (id != productDto.ProductId)
            {
                return BadRequest();
            }

            var result = await _productBusiness.UpdateProductAsync(productDto);
            if (result != null)
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]      
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productBusiness.DeleteProductAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
