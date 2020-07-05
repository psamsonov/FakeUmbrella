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
                var willItRain = WeatherService.WillItRain(x.Latitude, x.Longitude);
                //Explicitly checking for true since it can also be null
                if (!string.IsNullOrEmpty(willItRain))
                {
                    x.WillRain = true;
                    x.WhenWillItRain = willItRain;
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
                var whenWillItRain = WeatherService.WillItRain(customer.Latitude, customer.Longitude);
                customer.WillRain = !String.IsNullOrWhiteSpace(whenWillItRain);
                customer.WhenWillItRain = whenWillItRain;
            }

            return customers;
        }
    }
}
