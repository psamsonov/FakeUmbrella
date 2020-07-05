using FakeUmbrellaAPI.Models;
using FakeUmbrellaAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeUmbrellaAPI.Services
{
    public class CustomerService
    {
        public static IEnumerable<Customer> GetCustomers()
        {
            return CustomerRepository.GetCustomers();
        }

        public static Customer GetCustomer(Guid id)
        {
            return CustomerRepository.GetCustomer(id);
        }


        public static IEnumerable<Customer> GetCustomersForRain()
        {
            var customers =  CustomerRepository.GetCustomers();
            var rainCustomers = new List<Customer>();

            customers.ToList().ForEach((x) =>
            {
                //Explicitly checking for true since it can also be null
                if (WeatherService.WillItRain(x.Latitude, x.Longitude) == true)
                {
                    x.WillRain = true;
                    rainCustomers.Add(x);
                }
            } );

            return rainCustomers;
        }

        public static void CreateCustomer(Customer customer)
        {
            CustomerRepository.CreateCustomer(customer);
        }

        public static void UpdateCustomer(Guid id, Customer customer)
        {
            CustomerRepository.UpdateCustomer(id, customer);
        }

        public static void DeleteCustomer(Guid id)
        {
            CustomerRepository.DeleteCustomer(id);
        }

        public static IEnumerable<Customer> GetCustomersWithRain()
        {
            var list = new List<Customer>();
            //TODO: some stuff

            return list;
        }

        public static IEnumerable<Customer> GetTopCustomers()
        {
            var customers = CustomerRepository.GetTopCustomers(4);

            foreach (var customer in customers)
            {
                customer.WillRain = WeatherService.WillItRain(customer.Latitude, customer.Longitude);
            }

            return customers;
        }
    }
}
