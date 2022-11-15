using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleAPI.Models;
using VehicleAPI.Models.Abstract;
using VehicleAPI.Services.Abstract;

namespace VehicleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IScopedService scopedService;

        public VehiclesController(IScopedService scopedService)
        {
            this.scopedService = scopedService;
        }

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


        [HttpGet("[action]")]
        public IActionResult GetCarList()
        {
            var result = CarList.ToList();
            return Ok(result);
        }



        [HttpGet("[action]/{color}")]
        public IActionResult GetCarListByColor(string color)
        {
            var result = CarList.Where(x => x.Color == color).FirstOrDefault();
            return Ok(result);
        }

        [HttpPost("[action]/{id}")]
        public IActionResult ChangeHeadlightsById(int id)
        { 
            var car = CarList.Where(x => x.Id == id).FirstOrDefault();
            var index = CarList.FindIndex(x => x.Id == id);
            car.Headlight = !car.Headlight;
            CarList[index] = car;

            return Ok(car);
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteCar(int id)
        {
            var deletedItem = CarList.Where(x => x.Id == id).FirstOrDefault();
            CarList.Remove(deletedItem);
            
            return Ok(CarList);
        }

        [HttpGet("[action]")]
        public IActionResult SelectVehicle(int id,string type)
        {
            Vehicle vehicle = scopedService.SelectVehicle(id, type);
            return Ok(vehicle);
        }
    }
}
