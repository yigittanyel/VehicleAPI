using VehicleAPI.Models;
using VehicleAPI.Models.Abstract;
using VehicleAPI.Services.Abstract;

namespace VehicleAPI.Services.Concrete
{
    public class ScopeManager : IScopedService
    {
        List<Car> CarList = new List<Car>()
        {
            new Car(){Id=0,Wheels=true,Headlight=true,Color="Red"},
            new Car(){Id=1,Wheels=true,Headlight=true,Color="Blue"},
            new Car(){Id=2,Wheels=true,Headlight=true,Color="White"},
            new Car(){Id=3,Wheels=true,Headlight=true,Color="Black"}
        };

        List<Bus> BusList = new List<Bus>()
        {
            new Bus(){Id=0,Color="Red"},
            new Bus(){Id=1,Color="Blue"},
            new Bus(){Id=2,Color="White"},
            new Bus(){Id=3,Color="Black"},
        };
        List<Boat> BoatList = new List<Boat>()
        {
            new Boat(){Color="Red"},
            new Boat(){Color="Blue"},
            new Boat(){Color="White"},
            new Boat(){Color="Black"},
        };
        public Vehicle SelectVehicle(int id, string type)
        {
            if (type == "Bus")
                return BusList.Where(x => x.Id == id).FirstOrDefault();
            if (type == "Car")
                return CarList.Where(x => x.Id == id).FirstOrDefault();
            if (type == "Boat")
                return BoatList.Where(x => x.Id == id).FirstOrDefault();

            return null;
        }
    }
}
