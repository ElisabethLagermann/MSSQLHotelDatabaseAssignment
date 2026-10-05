
using HotelConsoleApp;
using HotelConsoleApp.Model;

HotelDBConnection dbConnection = new HotelDBConnection();

Customer customer1 = new Customer(1, "Elisabeth Lagermann", "12345678");

Customer customer2 = new Customer(2, "Victoria Bruhn", "23456789");

dbConnection.Create(customer1);
dbConnection.Create(customer2);

Console.WriteLine("Viser alle customers i databasen");
Console.WriteLine();

List<Customer> allCustomers = dbConnection.ReadAll();

foreach(Customer c in dbConnection.ReadAll())
{
    Console.WriteLine(c);
}

Console.WriteLine();
Console.WriteLine("Finder en customer med ID = 160");

Customer customerWithId10 = dbConnection.ReadById(160);

Console.WriteLine(customerWithId10);


Customer newCustomerJA = new Customer(5, "Julie Andersen", "25262728");

dbConnection.Update(110, newCustomerJA);

Console.WriteLine();
Console.WriteLine("Opdaterer customer med ID = 110 med ny kunde (Julie Andersen)");
Console.WriteLine();

foreach (Customer c in dbConnection.ReadAll())
{
    Console.WriteLine(c);
}
