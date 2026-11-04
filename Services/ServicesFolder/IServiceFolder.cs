
using ConsoleApp12.Models;

namespace ConsoleApp12.Services.ServicesFolder;

internal interface IServiceFolder
{
    public bool AddService(Service service);
    public Service GetService(int Id);
    public List<Service> GetServices();
    public void DeleteService(int Id, List<Service> services);

}
