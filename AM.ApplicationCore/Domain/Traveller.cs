using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller: Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality { get; set; }

        //TP1-Q6: Réimplémenter la méthode ToString()
        public override string ToString()
        {
            base.ToString();
            return "HealthInformation: " + HealthInformation + " Nationality : " + Nationality ;
        }

        //TP1-Q11.b: Réimplémenter la méthode PassengerType()
        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("and I'm a traveller");
        }
    }
}
