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
    }
}
