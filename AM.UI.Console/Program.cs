// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

//Console.WriteLine("Hello, World!");

//TP1-Q7: Créer un objet de type Plane en utilisant le constructeur non paramétré
Plane plane1 = new Plane();
plane1.PlaneType = PlaneType.Airbus;
plane1.Capacity = 200;
plane1.ManufactureDate = new DateTime(2018, 11, 10);

//TP1-Q8: Créer un objet de type Plane en utilisant le constructeur paramétré
Plane plane2 = new Plane(PlaneType.Boing, 300, DateTime.Now);

//TP1-Q9: Créer un objet de type Plane en utilisant l'initialiseur d'objet
Plane plane3 = new Plane
{
    PlaneType = PlaneType.Airbus,
    Capacity = 150,
    ManufactureDate = new DateTime(2015, 02, 03)
};

Console.WriteLine("************************************ Testing Signature Polymorphisme ****************************** ");
Passenger p1 = new Passenger { FirstName = "steave", LastName = "jobs", EmailAddress = "steeve.jobs@gmail.com", BirthDate = new DateTime(1955, 01, 01) };
Console.WriteLine("La méthode CheckProfile:");
Console.WriteLine(p1.CheckProfile("steave", "jobs"));
Console.WriteLine(p1.CheckProfile("steave", "jobs", "steeve.jobs@gmail.com"));

Console.WriteLine("************************************ Testing Inheritance Polymorphisme ****************************** ");
Staff s1 = new Staff { FirstName = "Bill", LastName = "Gates", EmailAddress = "Bill.gates@gmail.com", BirthDate = new DateTime(1945, 01, 01), EmployementDate = new DateTime(1990, 01, 01), Salary = 99999 };
Traveller t1 = new Traveller { FirstName = "Mark", LastName = "Zuckerburg", EmailAddress = "Mark.Zuckerburg@gmail.com", BirthDate = new DateTime(1980, 01, 01), HealthInformation = "Some troubles", Nationality = "American" };
Console.WriteLine("La méthode PassengerType p1:");
p1.PassengerType();
Console.WriteLine("La méthode PassengerType s1:");
s1.PassengerType();
Console.WriteLine("La méthode PassengerType t1:");
t1.PassengerType();
FlightMethods fm = new FlightMethods();
fm.Flights = TestData.listFlights;
foreach (var item in fm.GetFlightDates("Paris")) 
{
    Console.WriteLine(item);
}
fm.GetFlights("Destination", "Paris");
fm.DestinationGroupedFlights();
fm.ShowFlightDetails(TestData.Airbusplane);
Console.WriteLine("ProgrammedFlightNumber");
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2022, 01, 27)));
Console.WriteLine(fm.DurationAverage("Madrid"));
foreach (var item in fm.OrderedDurationFlights())
{
    Console.WriteLine(item);
}
foreach (var item in fm.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(item);
}
Console.WriteLine("delegué");
fm.FlightDetailsDel(TestData.BoingPlane);
Console.WriteLine("delegué 2");
Console.WriteLine( fm.DurationAverageDel("Madrid"));