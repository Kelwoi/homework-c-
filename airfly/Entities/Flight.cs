using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airfly.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DepartureLocation { get; set; }
        public string ArrivalLocation { get; set; }
        public ICollection<ClientFlight> ClientFlights { get; set; }
    }
}
