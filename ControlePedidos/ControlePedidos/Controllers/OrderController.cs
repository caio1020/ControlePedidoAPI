using ControlePedidos.Entity;
using ControlePedidos.Interfaces.Services;
using ControlePedidos.Model;
using ControlePedidos.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControlePedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;   
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var response = _orderService.GetAll();

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
                var response = _orderService.GetById(id);

                return Ok(response);
            }
            catch (Exception exception)
            {

                return StatusCode(500, "Erro interno do servidor: " + exception.Message);
            }
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] InsertOrderModel request)
        {

            try
            {
                _orderService.Insert(request);

                return Ok();
            }
            catch (Exception exception)
            {

                return StatusCode(500, "Erro interno do servidor: " + exception.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] UpdateOrderModel request)
        {

            try
            {
                _orderService.Update(request);

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
                _orderService.Delete(id);

                return Ok();
            }
            catch (Exception exception)
            {

                return StatusCode(500, "Erro interno do servidor: " + exception.Message);
            }
        }

    }
}
