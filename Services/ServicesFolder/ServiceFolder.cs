using System.Globalization;
using ConsoleApp12.Enums;
using ConsoleApp12.Models;

namespace ConsoleApp12.Services.ServicesFolder;

internal class ServiceFolder : IServiceFolder
{
    string path = "C:\\Users\\teacher\\source\\repos\\ConsoleApp12\\Data\\Service.txt";

    public bool AddService(Service service)
    {
        Console.Write("Enter ID: ");
        service.Id = int.Parse(Console.ReadLine());

        Console.Write("Enter category: ");
        service.Category = Enum.Parse<Category>(Console.ReadLine(), true);

        Console.Write("Enter price: ");
        service.Price = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Enter duration in minutes: ");
        service.DurationInMinutes = int.Parse(Console.ReadLine());

        Console.Write("Enter description: ");
        service.Description = Console.ReadLine();

        Console.Write("Is it shipable? (true/false): ");
        service.IsShipable = bool.Parse(Console.ReadLine());

        string line = $"{service.Id}|{service.Category}|{service.Price.ToString(CultureInfo.InvariantCulture)}|{service.DurationInMinutes}|{service.Description}|{service.IsShipable}";
        File.AppendAllText(path, line + Environment.NewLine);

        return true;
    }

    public void DeleteService(int Id, List<Service> services)
    {
        var service = services.FirstOrDefault(s => s.Id == Id);

        if (service == null)
        {
            Console.WriteLine("Service not found.");
            return;
        }

        services.Remove(service);

        var lines = new List<string>();
        foreach (var s in services)
        {
            lines.Add($"{s.Id}|{s.Category}|{s.Price.ToString(CultureInfo.InvariantCulture)}|{s.DurationInMinutes}|{s.Description}|{s.IsShipable}");
        }
        File.WriteAllLines(path, lines);

        Console.WriteLine("Service deleted.");
    }

    public Service GetService(int Id)
    {
        return GetServices().FirstOrDefault(s => s.Id == Id);
    }

    public List<Service> GetServices()
    {
        List<Service> services = new();

        if (!File.Exists(path))
            return services;

        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var parts = line.Split('|');

            var service = new Service(
                int.Parse(parts[0]),
                Enum.Parse<Category>(parts[1], true),
                decimal.Parse(parts[2], CultureInfo.InvariantCulture),
                int.Parse(parts[3]),
                parts[4],
                bool.Parse(parts[5]));

            services.Add(service);
        }

        return services;
    }
}
