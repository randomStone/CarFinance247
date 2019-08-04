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

        public Customer CreatedCustomer {get; private set;}
        public Customer UpdatedCustomer {get; private set;}
        public Guid DeletedCustomerId {get; private set;}

        public Task CreateCustomer(Guid id, string FirstName, string Surname, string EMail, string customerPassword)
        {
            this.GetCustomerByIDData = new Customer(){ID=id,FirstName = FirstName,Surname = Surname,EMail = EMail,CustomerPassword=customerPassword};
            this.CreatedCustomer =this.GetCustomerByIDData;
            return Task.CompletedTask;
        }

        public Task DeleteCustomer(Guid id)
        {
          this.DeletedCustomerId =id;
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Customer>> getAllCustomers()
        {
            
            return Task.FromResult(GetAllCustomersData);
        }

        public Task<Customer> getCustomerByID(Guid id)
        {
             return Task.FromResult(GetCustomerByIDData);
        }

        public Task UpdateCustomer(Guid id, string FirstName, string Surname, string EMail, string customerPassword)
        {
            this.GetCustomerByIDData = new Customer(){ID=id,FirstName = FirstName,Surname = Surname,EMail = EMail,CustomerPassword=customerPassword};
            this.UpdatedCustomer =this.GetCustomerByIDData;
            return Task.CompletedTask;
        }
    }
}