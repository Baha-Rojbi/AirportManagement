using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        private IUnitOfWork UnitOfWork;
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public IEnumerable<Staff> GetStaff(int idFlight)
        {
            ////Retourner la liste des staffs d’un vol dont son identifiant est passé en paramètre.
            //return GetById(idFlight).Tickets.Select(t=>t.MyPassenger).OfType<Staff>().ToList();
            return UnitOfWork.Repository<Flight>().GetById(idFlight).Tickets.Select(t => t.MyPassenger).OfType<Staff>().ToList();
        }
        //Retourner la liste des voyageurs qui ont voyagé dans un avion donné à une date
        // donnée.
        public IEnumerable<Traveller> GetPassengersByPlaneAndDate(Plane plane, DateTime flightDate)
        {
            return GetMany(f=>f.FlightDate==flightDate && f.Plane.PlaneId==plane.PlaneId).SelectMany(f=>f.Tickets).Select(t=>t.MyPassenger).OfType<Traveller>().ToList();
        }
        //- Afficher le nombre de voyageurs par date de vol. Cette dernière doit être comprise
        // entre deux dates données.
        public int NbVoyageurByDates(DateTime startDate, DateTime endDate)
        {
            return GetMany(f=>f.FlightDate>=startDate && f.FlightDate<=endDate).SelectMany(f=>f.Tickets).Select(t=>t.MyPassenger).OfType<Traveller>().Count();
        }

        public void GroupTraveller(DateTime startDate, DateTime endDate)
        {
           var query= GetMany(f => f.FlightDate >= startDate && f.FlightDate <= endDate).SelectMany(f => f.Tickets)
                .GroupBy(t => t.MyFlight.FlightDate)
                .Select(t => new {group=t.Key,nbre=t.Count()});
            foreach (var item in query)
            {
                Console.WriteLine("Date de vol = " + item.group + " nombre de passenger = " + item.nbre);
            }
           
        }
    }
}
