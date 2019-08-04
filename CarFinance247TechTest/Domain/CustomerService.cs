
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

        public async Task<Customer> GetCustomerByID(Guid id)
        {
            return await this.repository.getCustomerByID(id);
        }

        public async Task<Customer> CreateCustomer(CreateCustomerRequest customer)
        {

            await this.repository.CreateCustomer(customer.ID, customer.FirstName, customer.Surname, customer.EMail, customer.CustomerPassword);
            return await this.GetCustomerByID(customer.ID);
        }

        public async Task<Customer> UpdateCustomer(UpdateCustomerRequest customer, Guid Id)
        {
            await this.repository.UpdateCustomer(Id, customer.FirstName, customer.Surname, customer.EMail, customer.CustomerPassword);
            return await this.GetCustomerByID(Id);
        }

        public async Task<Customer> DeleteCustomer(Guid Id)
        {
            var customer = await this.GetCustomerByID(Id);
            await this.repository.DeleteCustomer(Id);
            return customer;
        }

    }
}
