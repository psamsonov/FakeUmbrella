using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeUmbrellaAPI.Exceptions
{
    public class WeatherAPIUnavailableException : Exception
    {
        public WeatherAPIUnavailableException(string message) : base(message) { }
    }
}
