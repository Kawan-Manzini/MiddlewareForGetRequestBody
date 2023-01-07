using AluCarWepApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AluCarWepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        public static List<Vehicle> DB_VEHICLES { get; set; } = new List<Vehicle>();
        public VehicleController() { }

        [HttpGet("vehicles")]
        public List<Vehicle> GetAll()
        {
            return DB_VEHICLES;
        }


        [HttpGet("vehicles/{id}")]
        public Vehicle GetAll(Guid id)
        {
            return DB_VEHICLES.FirstOrDefault(_ => _.Id == id);
        }

        [HttpPost("vehicles")]
        public Vehicle Add([FromBody] Vehicle vehicle) 
        {
             DB_VEHICLES.Add(vehicle);
            return vehicle;
        }


        [HttpPut("vehicles")]
        public Vehicle Update([FromBody] Vehicle vehicle) 
        {
            var currentValue = DB_VEHICLES.FirstOrDefault(_ => _.Id == vehicle.Id);
            if(currentValue != null)
            {
                currentValue.StoreId = vehicle.StoreId;
                currentValue.Plate = vehicle.Plate;
                currentValue.Type = vehicle.Type;
            }
            return vehicle;
        }
        
        [HttpDelete("vehicles/{id}")]
        public string Delete(Guid id) 
        {
            var currentValue = DB_VEHICLES.FirstOrDefault(_ => _.Id == id);
            if(currentValue != null)
            {
                DB_VEHICLES.Remove(currentValue);
            }
            else
            {
                return $"item {id} nao encontrado";
            }
            return $"{id} removido!";
        }



    }
}