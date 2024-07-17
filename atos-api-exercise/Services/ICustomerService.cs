using atos_api_exercise.Models;

namespace atos_api_exercise.Services
{
    public interface ICustomerService
    {
        Customer AddCustomer(NewCustomer customer);
        bool RemoveCustomer(int customerId);
        List<Customer> GetAllCustomers();
    }
}
