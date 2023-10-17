using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods: IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();
        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDel;
        public FlightMethods()
        {
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;
            DurationAverageDel = destination =>
            {
                var requete = from f in Flights
                              where (f.Destination == destination)
                              select f.EstimatedDuration;
                return requete.Average();
            };

            FlightDetailsDel = plane =>
            {
                var requete = from
               f in Flights
                              where f.Plane == plane
                              select new { f.Destination, f.FlightDate };
                foreach (var f in requete)
                {
                    Console.WriteLine("la destination = " + f.Destination + " la date est = " + f.FlightDate);
                }
            };
        }

        public List<DateTime> GetFlightDates(string destination)
        {
          List<DateTime> dates = new List<DateTime>();
            //IEnumerable<DateTime> requete = from f in Flights
            //                                where f.Destination == destination
            //                                select f.FlightDate;
            ////////////////////////////////
            

            ////////////////
            //foreach (Flight f in Flights)
            //{
            //    if (f.Destination == destination)
            //    {
            //        dates.Add(f.FlightDate);
            //    }
            //}
            //////////////////
            ///
            //for(int i = 0; i < Flights.Count; i++)
            //{
            //    if (Flights[i].Destination == destination)
            //    {
            //        dates.Add(Flights[i].FlightDate);
            //    }
            //}
            //return requete.ToList();
            return Flights.Where(f => destination == destination).Select(f => f.FlightDate).ToList();
           
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach(Flight f in Flights)
                    {
                        if(f.Destination.Equals(filterValue))
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate== DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
                case "FlightId":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightId== int.Parse(filterValue))
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
            }
        }

       

        public void ShowFlightDetails(Plane plane)
        {
            //var requete =from 
            //    f in Flights
            //    where f.Plane == plane
            //    select new {f.Destination, f.FlightDate};
            //foreach (var f in requete)
            //{
            //    Console.WriteLine("la destination = "+f.Destination+" la date est = "+f.FlightDate);
            //}
            var requests = Flights.Where(f=>f.Plane == plane);
            foreach(var f in requests)
            {
                Console.WriteLine("la destination = " + f.Destination + " la date est = " + f.FlightDate);
            }
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var requete = from f in Flights
            //              where (f.FlightDate - startDate).TotalDays < 7 && DateTime.Compare(f.FlightDate, startDate) > 0
            //              select f;
            //return requete.Count();
            var request = Flights.Where(f=>(f.FlightDate - startDate).TotalDays<7 && DateTime.Compare(f.FlightDate, startDate)>0);
            return request.Count();
                          
        }

        public double DurationAverage(string destination)
        {
            //var requete = from f in Flights
            //              where (f.Destination == destination)
            //              select f.EstimatedDuration;
            //return requete.Average();
            return Flights.Where(f => f.Destination == destination).Average(f=>f.EstimatedDuration);
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
           /* var requete=from f in Flights
                        orderby f.EstimatedDuration descending
                        select f;
            return requete;*/
           return Flights.OrderByDescending(f => f.FlightDate);

        }

        public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            //var requete = from f in flight.Passengers
            //                       where f is Traveller
            //                       orderby f.BirthDate ascending
            //                       select f ;


            /*var requete = from p in flight.Passengers.OfType<Traveller>()
                          orderby p.BirthDate ascending
                          select p;

            return requete.Take(3);*/
             return flight.Passengers.Where(p=> p is Traveller).OrderBy(t=>t.BirthDate).Take(3);
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            //var requete = from f in Flights
            //              group f by f.Destination;
            var requete = Flights.GroupBy(f => f.Destination);
            foreach (var g in requete)
            {
                Console.WriteLine("Destination " + g.Key);
                foreach(var f in g)
                {
                    Console.WriteLine("Decolage : " + f.FlightDate);
                }
            }
            return requete;
        }

     

    }
}
