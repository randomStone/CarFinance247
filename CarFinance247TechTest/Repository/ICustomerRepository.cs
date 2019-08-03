using System.Collections.Generic;
using System.Threading.Tasks;
using CarFinance247TechTest.Modal;

namespace CarFinance247TechTest.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> getAllCustomers();
    }
}
