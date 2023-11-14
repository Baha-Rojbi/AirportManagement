using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Passenger> getPassengers(Plane plane)
        {
            return GetById(plane.PlaneId).Flights.SelectMany(f=>f.Tickets.Select(t=>t.MyPassenger)).ToList();
        }

        public IList<Flight> getFlights(int n)
        {
            return GetAll().OrderByDescending(p => p.PlaneId).Take(n).SelectMany(p => p.Flights).ToList();
        }

        public bool AvailablePlane(int n, Flight flight)
        {
            int capacity = Get(p => p.Flights.Contains(flight) == true).Capacity;
            int nbrePassager = flight.Tickets.Count;
            return capacity >= nbrePassager+n;
        }

        public void DeletePlanes()
        {
            foreach (var plane in GetAll().Where(p => (DateTime.Now - p.ManufactureDate).TotalDays > 365 * 10).ToList())
            {
                Delete(plane);
                Commit();
            }
        }
    }
}
