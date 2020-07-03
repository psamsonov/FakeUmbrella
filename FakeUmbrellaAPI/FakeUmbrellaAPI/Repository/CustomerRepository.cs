using FakeUmbrellaAPI.Exceptions;
using FakeUmbrellaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeUmbrellaAPI.Repository
{

    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=FakeUmbrella.db");
    }

    public class CustomerRepository
    {
        public static void CreateCustomer(Customer customer)
        {
            using (var db = new CustomerContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
        }

        public static Customer GetCustomer(Guid customerId)
        {
            using (var db = new CustomerContext())
            {
                var entity = db.Customers.AsNoTracking().Where(x => x.Id == customerId).FirstOrDefault();
                if (entity != null)
                {
                    return entity;
                }
                else
                {
                    throw new NotFoundException();
                }
            }
        }

        public static void DeleteCustomer(Guid customerId)
        {
            using (var db = new CustomerContext())
            {
                var entity = db.Customers.Where(x => x.Id == customerId).FirstOrDefault();
                if (entity != null)
                {
                    db.Customers.Remove(entity);
                    db.SaveChanges();
                }
                else
                {
                    throw new NotFoundException();
                }
            }
        }

        public static IEnumerable<Customer> GetTopCustomers(int number)
        {
            using (var db = new CustomerContext())
            {
                var customers = db.Customers.AsNoTracking().OrderBy(x => x.NumberOfEmployees).Take(number).ToList();
                return customers;
            }
        }

        public static IEnumerable<Customer> GetCustomers()
        {
            using (var db = new CustomerContext())
            {
                var customers = db.Customers.AsNoTracking().ToList();
                return customers;
            }
        }

        public static void UpdateCustomer(Guid customerId, Customer customer)
        {
            using (var db = new CustomerContext())
            {
                var entity = db.Customers.Where(x => x.Id == customerId).FirstOrDefault();
                if (entity != null)
                {
                    entity.ContactName = customer.ContactName;
                    entity.ContactPhoneNumber = customer.ContactPhoneNumber;
                    entity.Latitude = customer.Latitude;
                    entity.Longitude = customer.Longitude;
                    entity.NumberOfEmployees = customer.NumberOfEmployees;
                    entity.CustomerName = customer.CustomerName;

                    db.SaveChanges();
                }
                else
                {
                    throw new NotFoundException();
                }
            }
        }
    }
}
