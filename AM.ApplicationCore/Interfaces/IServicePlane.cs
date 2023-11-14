using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane :IService<Plane>
    {
        IList<Passenger> getPassengers(Plane plane);
        IList<Flight> getFlights(int n);
        bool AvailablePlane(int n, Flight flight);
        void DeletePlanes();
    }
}
