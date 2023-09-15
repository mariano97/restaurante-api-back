using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestauranteApi.Servicios;
using RestauranteApi.Servicios.Mappers.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestauranteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {

        private IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }


        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var lista = await _service.GetAll();
                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDTO value)
        {

            try
            {
                value = await _service.Guardar(value);
                return Ok(value);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}

