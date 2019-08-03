using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using CarFinance247TechTest.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CarFinance247TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService service;

        public CustomerController (CustomerService service){
            this.service = service;
        }
        // GET api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var result = await this.service.getAllCustomers();
            return new OkObjectResult(result); 
        }

      
    }
}
