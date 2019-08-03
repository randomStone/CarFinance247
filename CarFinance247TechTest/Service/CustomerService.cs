
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarFinance247TechTest.Modal;
using CarFinance247TechTest.Repository;

namespace CarFinance247TechTest.Domain
{
    public class CustomerService
    {

        private readonly ICustomerRepository repository;
        public CustomerService(ICustomerRepository repo)
        {
            this.repository = repo;
        }

        public async Task<IEnumerable<Customer>> getAllCustomers()
        {
            return await this.repository.getAllCustomers();
        }

        public async Task<Customer> GetCustomerByID(Guid id){
            return await this.repository.getCustomerByID(id);
        }

    }
}
