using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff: Passenger
    {
        public string Function { get; set; }
        public DateTime EmployementDate { get; set; }
        [DataType(DataType.Currency)]
        public float Salary { get; set; }

        //TP1-Q6: Réimplémenter la méthode ToString()
        public override string ToString()
        {
            base.ToString();
            return "Function: " + Function + " EmployementDate : " + EmployementDate + " Salary: " + Salary;
        }

        //TP1-Q11.b: Réimplémenter la méthode PassengerType()
        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("and I'm a staff member");
        }
    }
}
