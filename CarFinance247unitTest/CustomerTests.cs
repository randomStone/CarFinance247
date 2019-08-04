using System.Linq;
using System;
using System.Collections.Generic;
using CarFinance247TechTest.Modal;
using Xunit;
using CarFinance247TechTest.Domain;
using System.Threading.Tasks;

namespace CarFinance247unitTest
{
    public class CustomerTest 
    {
        [Fact]
        public async Task GetAllCustomers()
        {
            var expected =  new List<Customer>(){
                new Customer(){ID=Guid.NewGuid(),FirstName="Bob",Surname ="Bobby",EMail ="bob@bobby.com",CustomerPassword ="password"},
                new Customer(){ID=Guid.NewGuid(),FirstName="Bob",Surname ="Bobby",EMail ="bob@bobby.com",CustomerPassword ="password"}
            };
           
            var fakeRepo = new FakeCustomerRepository();
            fakeRepo.GetAllCustomersData = expected;
            var customerService =new CustomerService(fakeRepo);
            
            var result = await customerService.getAllCustomers();
            Assert.NotNull(result);
            
            Assert.Equal(2,result.Count());
            Assert.Equal(expected,result);
        }
        [Fact]
        public async Task GetCustomerByID(){
            var id = Guid.NewGuid();
            var expected = new Customer(){ID=id,FirstName="Bob",Surname ="Bobby",EMail ="bob@bobby.com",CustomerPassword ="password"};

            var fakeRepo = new FakeCustomerRepository();
            fakeRepo.GetCustomerByIDData = expected;
            var customerService =new CustomerService(fakeRepo);
            
            var result = await customerService.GetCustomerByID(id);

            Assert.NotNull(result);
            Assert.Equal(expected.ID,result.ID);
            Assert.Equal(expected.FirstName,result.FirstName);

        }

        [Fact]
        public async Task CreateCustomer(){
            var id = Guid.NewGuid();
            var newCustomer = new CreateCustomerRequest(){ 
                ID=id,
                FirstName="Bob",
                Surname ="Bobby",
                EMail ="bob@bobby.com",
                CustomerPassword ="password"
            };
            var fakeRepo = new FakeCustomerRepository();
            var customerService =new CustomerService(fakeRepo);

            var result = await customerService.CreateCustomer(newCustomer);

            Assert.NotNull(result);
            Assert.Equal(newCustomer.ID,result.ID);
            Assert.Equal(newCustomer.FirstName,result.FirstName);
            Assert.NotNull(fakeRepo.CreatedCustomer);
            Assert.Equal(newCustomer.ID,fakeRepo.CreatedCustomer.ID);
            Assert.Equal(newCustomer.FirstName,fakeRepo.CreatedCustomer.FirstName);

        }

         [Fact]
        public async Task UpdateCustomer(){
            var id = Guid.NewGuid();
            var updatedCustomer = new UpdateCustomerRequest(){ 
            
                FirstName="Bob",
                Surname ="Bobby",
                EMail ="bob@bobby.com",
                CustomerPassword ="password"
            };
            var fakeRepo = new FakeCustomerRepository();
            var customerService =new CustomerService(fakeRepo);

            var result = await customerService.UpdateCustomer(updatedCustomer,id);

            Assert.NotNull(result);
            Assert.Equal(id,result.ID);
            Assert.Equal(updatedCustomer.FirstName,result.FirstName);
            Assert.NotNull(fakeRepo.UpdatedCustomer);
            Assert.Equal(id,fakeRepo.UpdatedCustomer.ID);
            Assert.Equal(updatedCustomer.FirstName,fakeRepo.UpdatedCustomer.FirstName);

        }

        [Fact]
        public async Task DeleteCustomer(){
            var id = Guid.NewGuid();

            var customerToBeDeleted = new Customer(){
                ID = id,
                FirstName="Bob",
                Surname ="Bobby",
                EMail ="bob@bobby.com",
                CustomerPassword ="password"
            };
            var fakeRepo = new FakeCustomerRepository();
            var customerService =new CustomerService(fakeRepo);

            var result = await customerService.DeleteCustomer(id);

            Assert.Equal(id,fakeRepo.DeletedCustomerId);

        }


      
     
    }
}
