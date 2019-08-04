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
        public async Task CreateCustomer(Guid id, string FirstName, string Surname, string EMail, string customerPassword)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(@"INSERT INTO CUSTOMERS (ID,FirstName, Surname, EMail,CustomerPassword)
                                                VALUES (@id,@firstName,@surname,@email,@customerPassword)",
                                                new { id = id, FirstName = FirstName, surname = Surname, email = EMail, customerPassword = customerPassword }).ConfigureAwait(false);
            }
        }

        public async Task UpdateCustomer(Guid id, string FirstName, string Surname, string EMail, string customerPassword)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(@"UPDATE CUSTOMERS
                                                SET FirstName = @firstName,Surname = @surname, EMail = @email,CustomerPassword = @customerPassword
                                                WHERE ID = @id",
                                                new { id = id, FirstName = FirstName, surname = Surname, email = EMail, customerPassword = customerPassword }).ConfigureAwait(false);
            }
        }

        public async Task DeleteCustomer(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(@"DELETE FROM CUSTOMERS
                                                WHERE ID = @id",
                                                    new { id = id }).ConfigureAwait(false);
            }
        }
    }
}