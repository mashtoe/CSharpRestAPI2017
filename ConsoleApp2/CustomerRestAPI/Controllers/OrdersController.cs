using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsoleApp2BLL;
using ConsoleApp2BLL.BusinessObjects;

namespace CustomerRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {

        BLLFacade facade = new BLLFacade();
        // GET: api/Orders
        [HttpGet]
        public IEnumerable<OrderBO> Get()
        {
            return facade.OrderService.GetAll();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public OrderBO Get(int id)
        {
            return facade.OrderService.Get(id);
        }
        
        // POST: api/Orders
        [HttpPost]
        public IActionResult Post([FromBody]OrderBO value)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            return Ok(facade.OrderService.Create(value));
        }
        
        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]OrderBO value)
        {
            if (id != value.Id)
            {
                return BadRequest("Path ID does not match Order ID in json object.");
            }

            try
            {
                return Ok(facade.OrderService.Update(value));
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(404,ex.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.OrderService.Delete(id);
        }
    }
}
