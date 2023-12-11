using ControlePedidos.Interfaces.Services;
using ControlePedidos.Model;
using Microsoft.AspNetCore.Mvc;

namespace ControlePedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var response = _productService.GetAll();

                return Ok(response);
            }
            catch (Exception exception)
            {

                return StatusCode(500, "Erro interno do servidor: " + exception.Message);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            try
            {
                var response = _productService.GetById(id);

                return Ok(response);
            }
            catch (Exception exception)
            {

                return StatusCode(500, "Erro interno do servidor: " + exception.Message);
            }
        }

        [HttpPost]
        [Route("Insert")]

        public IActionResult Insert([FromBody] InsertProductModel product)
        {
            try
            {
                _productService.Insert(product);

                return Ok();
            }
            catch (Exception exception)
            {

                return StatusCode(500, "Erro interno do servidor: " + exception.Message);
            }
        }

        [HttpPut]
        [Route("Update")]

        public IActionResult Update([FromBody] ProductModel product)
        {
            try
            {
                _productService.Update(product);

                return Ok();
            }
            catch (Exception exception)
            {

                return StatusCode(500, "Erro interno do servidor: " + exception.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);

                return Ok();
            }
            catch (Exception exception)
            {

                return StatusCode(500, "Erro interno do servidor: " + exception.Message);
            }
        }
    }
}
