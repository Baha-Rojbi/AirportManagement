using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods 
    {
        public List<DateTime> GetFlightDates(string destination);
        public void GetFlights(string filterType, string filterValue);
        public void ShowFlightDetails(Plane plane);
        public int ProgrammedFlightNumber(DateTime startDate);
        public double DurationAverage(string destination);
        public IEnumerable<Flight> OrderedDurationFlights();
        public IEnumerable<Passenger> SeniorTravellers(Flight flight);
        public IEnumerable<IGrouping<String, Flight>> DestinationGroupedFlights();
    }
}
