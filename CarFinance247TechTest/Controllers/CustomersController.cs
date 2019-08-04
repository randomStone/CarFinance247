using System.Collections.Generic;
using System.Threading.Tasks;
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

        // POST api/Customer
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] CreateCustomerRequest customer)
        {
            if(!ModelState.IsValid){
                return BadRequest();
            }

            var result = await this.service.CreateCustomer(customer);
            return CreatedAtAction(nameof(Get),new {id=result.ID},result);

        }

         // PUT api/Customer/Guid
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>>  Put([FromBody] UpdateCustomerRequest customer,Guid Id)
        {
             if(!ModelState.IsValid){
                return BadRequest();
            }

            var result = await this.service.UpdateCustomer(customer,Id);
            return new OkObjectResult(result);
        }

         // DELETE api/Customer/Guid
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(Guid id)
        {
              var result = await this.service.DeleteCustomer(id);
            return new OkObjectResult(result); 
        }
        
    }
}
