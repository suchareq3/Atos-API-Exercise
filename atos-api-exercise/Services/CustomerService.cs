using atos_api_exercise.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace atos_api_exercise.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers;
        public CustomerService()
        {
            _customers = new()
            {
                new()
                {
                    Id = 1,
                    Firstname = "Some1",
                    Surname = "Person1"
                }
            };
            
         }
        public Customer AddCustomer(NewCustomer newCustomer)
        {
            var customer = new Customer
            {
                //Id = _customers.Count + 1,
                Id = _customers.Max(customer => customer.Id) + 1,
                Firstname = newCustomer.Firstname,
                Surname = newCustomer.Surname,
            };

            _customers.Add(customer);
            return customer;
        }

        public bool RemoveCustomer(int customerId)
        {
            var removedCustomer = _customers.Find(c => c.Id == customerId);
            if (removedCustomer != null)
            {
                _customers.Remove(removedCustomer);
                return true;
            }
            return false;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }
    }

}