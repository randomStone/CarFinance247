using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using CarFinance247TechTest.Domain;
using Microsoft.AspNetCore.Mvc;
using CarFinance247TechTest.Modal;
using System;

namespace CarFinance247TechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService service;

        public CustomerController(CustomerService service)
        {
            this.service = service;
        }
        // GET api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            var result = await this.service.getAllCustomers();
            return new OkObjectResult(result);
        }
        // GET api/Customer/guid
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(Guid id)
        {
            var result = await this.service.GetCustomerByID(id);
            if (result != null)
            {
                return new OkObjectResult(result);
            }
            else
            {
                return new NotFoundResult();
            }

        }


    }
}
