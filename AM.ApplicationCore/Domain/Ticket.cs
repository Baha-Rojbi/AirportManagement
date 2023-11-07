using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public virtual double Prix { get; set; }
        public virtual int Siege { get; set; }
        public virtual bool Vip { get; set; }
        public virtual Passenger MyPassenger { get; set; }
        public virtual Flight MyFlight { get; set; }

        [ForeignKey("MyPassenger")]
        public string PassengerFk { get; set; }
        [ForeignKey("MyFlight")]
        public int FlightFk { get; set; }   
    }       
}
