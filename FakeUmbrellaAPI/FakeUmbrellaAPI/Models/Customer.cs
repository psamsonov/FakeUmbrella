using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FakeUmbrellaAPI.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int NumberOfEmployees { get; set; }

        [NotMapped]
        public bool? WillRain { get; set; }

    }
}
