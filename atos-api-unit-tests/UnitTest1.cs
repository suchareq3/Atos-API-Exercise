using Moq;
using atos_api_exercise.Models;
using atos_api_exercise.Services;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using atos_api_exercise.Controllers;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace atos_api_unit_tests
{
    public class UnitTest1
    {
        private readonly HttpClient _httpClient;
        private readonly Mock<ICustomerService> _customerServiceMock;
        //private readonly ILogger<CustomerService> _mockLogger;
        public UnitTest1()
        {
            _httpClient = new HttpClient();
            _customerServiceMock = new Mock<ICustomerService>();
        }

        [Fact]
        public void AddCustomer_Test1()
        { //addCustomer should successfully add a new customer.
            var service = new CustomerService();
            var mockNewCustomer = new NewCustomer { Firstname = "TestName", Surname = "TestSurname" };

            var addedCustomer = service.AddCustomer(mockNewCustomer);

            Assert.NotNull(addedCustomer);
            Assert.Equal(mockNewCustomer.Firstname, addedCustomer.Firstname);
            Assert.Equal(mockNewCustomer.Surname, addedCustomer.Surname);
        }

        [Fact]
        public void AddCustomer_Test2()
        { //addCustomer's firstname and surname should default to empty strings if not provided.
            var service = new CustomerService();
            var mockNewCustomer = new NewCustomer();

            var addedCustomer = service.AddCustomer(mockNewCustomer);

            Assert.NotNull(addedCustomer);
            Assert.Equal("", addedCustomer.Firstname);
            Assert.Equal("", addedCustomer.Surname);
        }

        /*[Fact]
        public async Task AddCustomer_Test3()
        { // valid customer input should return a 200 OK response
            var mockCustomers = new List<Customer>
            {
                new Customer {Id = 1, Firstname = "name1", Surname="surname1"},
                new Customer {Id = 2, Firstname ="name2", Surname="surname2" },
            };


            _customerServiceMock.Setup(x => x.GetAllCustomers()).Returns(mockCustomers);

            var controller = new CustomerController(_customerServiceMock.Object, _mockLogger);

            IActionResult actionResult = controller.Get();
            var contentResult = actionResult;

            Assert.NotNull(contentResult);

        }*/

        [Fact]
        public void RemoveCustomer_Test1() 
        { //removeCustomer should successfully remove a customer by providing an ID.
            var service = new CustomerService();
            var mockRemoveCustomerID = 1;
            var mockRemoveCustomer = new NewCustomer { Firstname = "Delete", Surname = "Me, please!" };

            var result = service.RemoveCustomer(mockRemoveCustomerID);

            Assert.True(result);
        }

        [Fact]
        public void RemoveCustomer_Test2()
        { //removeCustomer should return an error if there's no customer with said ID.
            var service = new CustomerService();
            var mockRemoveCustomerID = 99;
            var mockRemoveCustomer = new NewCustomer { Firstname = "Delete", Surname = "Me, please!" };

            var result = service.RemoveCustomer(mockRemoveCustomerID);

            Assert.False(result);
        }

        [Fact]
        public void GetAllCustomers_Test1()
        {
            var service = new CustomerService();
            var result = service.GetAllCustomers();

            Assert.NotNull(result);
        }
    }
}