using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarFinance247TechTest.Modal;
using CarFinance247TechTest.Repository;

namespace CarFinance247unitTest
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> GetAllCustomersData {private get;  set; }
        public Customer GetCustomerByIDData {private get; set;}
        public Task<IEnumerable<Customer>> getAllCustomers()
        {
            
            return Task.FromResult(GetAllCustomersData);
        }

        public Task<Customer> getCustomerByID(Guid id)
        {
             return Task.FromResult(GetCustomerByIDData);
        }
    }
}