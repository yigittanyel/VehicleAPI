using VehicleAPI.Models.Abstract;

namespace VehicleAPI.Services.Abstract
{
    public interface IScopedService
    {
        Vehicle SelectVehicle(int id, string type);
    }
}
