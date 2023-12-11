using ControlePedidos.Interfaces.Services;
using ControlePedidos.Model;
using Microsoft.AspNetCore.Mvc;

namespace ControlePedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
               var response = _clientService.GetAll();

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
                var response = _clientService.GetById(id);

                return Ok(response);
            }
            catch (Exception exception)
            {

                return StatusCode(500, "Erro interno do servidor: " + exception.Message);
            }
        }

        [HttpPost]
        [Route("Insert")]

        public IActionResult Insert([FromBody] InsertClientModel client)
        {
            try
            {
                 _clientService.Insert(client);

                return Ok();
            }
            catch (Exception exception)
            {

                return StatusCode(500, "Erro interno do servidor: " + exception.Message);
            }
        }

        [HttpPut]
        [Route("Update")]

        public IActionResult Update([FromBody] ClientModel client)
        {
            try
            {
                _clientService.Update(client);

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
                _clientService.Delete(id);

                return Ok();
            }
            catch (Exception exception)
            {

                return StatusCode(500, "Erro interno do servidor: " + exception.Message);
            }
        }

    }
}
