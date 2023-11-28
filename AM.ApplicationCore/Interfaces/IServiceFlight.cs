using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight :IService<Flight>
    {
        //Retourner la liste des staffs d’un vol dont son identifiant est passé en paramètre.
        IEnumerable<Staff> GetStaff(int idFlight);
        //Retourner la liste des voyageurs qui ont voyagé dans un avion donné à une date
        // donnée.
        IEnumerable<Traveller> GetPassengersByPlaneAndDate(Plane plane, DateTime FlightDate);
        //- Afficher le nombre de voyageurs par date de vol. Cette dernière doit être comprise
        // entre deux dates données.
        int NbVoyageurByDates(DateTime startDate, DateTime endDate);
        public void GroupTraveller(DateTime startDate, DateTime endDate);
        public IEnumerable<Flight> SortFLights();
    }
}
