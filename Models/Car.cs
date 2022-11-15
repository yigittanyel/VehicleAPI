using VehicleAPI.Models.Abstract;

namespace VehicleAPI.Models
{
    public class Car:Vehicle
    {
        public bool Wheels { get; set; } = true;
        public bool Headlight { get; set; } = true; 
    }
}
