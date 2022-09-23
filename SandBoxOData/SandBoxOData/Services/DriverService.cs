using SandBoxOData.Models;

namespace SandBoxOData.Services
{
    public interface IDriverService
    {
        public IReadOnlyCollection<Driver> Get();
        public Driver GetById(int driverId);
    }

    public class DriverService : IDriverService
    {
        public IReadOnlyCollection<Driver> Get()
        {
            return new Driver[]
            {
                new Driver
            {
                Id = 1,
                Name = "Lea"
            },new Driver
            {
                Id = 2,
                Name = "Jane"
            }
            };
        }

        public Driver GetById(int driverId)
        {
            return new Driver
            {
                Id = driverId,
                Name = "Luca"
            };
        }
    }
}
