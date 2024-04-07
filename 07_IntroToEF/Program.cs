using _07_IntroToEF.Entities;

namespace _07_IntroToEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplaneDbContext context = new AirplaneDbContext();
            context.Clients.Add(new Client()
            {
                Name = "Vitaliy",
                Email = "vit@gmail.com",
                Birthday = new DateTime(2006, 12, 4)
            });
            //context.SaveChanges();

            foreach (var item in context.Clients)
            {
                Console.WriteLine($"Client : name - {item.Name}. Email: {item.Email}. Birthday : {item.Birthday?.ToShortDateString()}");
            }

            //LINQ to Entities
            var filteredFlights = context.Flights
                                    .Where(f => f.ArrivalCity == "Lviv")
                                    .OrderBy(f => f.DepartureTime);

            foreach (var f in filteredFlights)
            {
                Console.WriteLine($"Flight : {f.Number}. From : {f.DepartureCity,15} to {f.ArrivalCity}" +
                    $" Date :{f.DepartureTime.ToShortDateString(),20}");

            }

            var client = context.Clients.Find(1);
            if (client != null)
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }
        }
    }
}
