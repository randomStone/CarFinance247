using System.Data;
using System.Collections.Generic;
using CarFinance247TechTest.Modal;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System;

namespace CarFinance247TechTest.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string connectionString;


        public CustomerRepository(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }
        public async Task<IEnumerable<Customer>> getAllCustomers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return await connection.QueryAsync<Customer>(@" SELECT [ID],[FirstName],[Surname],[EMail],[CustomerPassword]   
                                                                From CUSTOMERS").ConfigureAwait(false);
            }

        }

        public async Task<Customer> getCustomerByID(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<Customer>(@"  SELECT [ID],[FirstName],[Surname],[EMail],[CustomerPassword] 
                                                                                From CUSTOMERS 
                                                                                WHERE [ID]=@id", new { id = id }).ConfigureAwait(false);
            }

        }
    }
}