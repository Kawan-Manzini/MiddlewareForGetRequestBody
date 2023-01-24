using AluCarWepApi.Enums;
using AluCarWepApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AluCarWepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentController : ControllerBase
    {
        public static List<Rent> DB_RENTS { get; set; } = new List<Rent>();
        public RentController() { }

        [HttpGet("")]
        public List<Rent> GetAll()
        {
            return DB_RENTS;
        }


        [HttpGet("/{id}")]
        public Rent GetAll(Guid id)
        {
            return DB_RENTS.FirstOrDefault(_ => _.Id == id);
        }

        [HttpPost("")]
        public Rent Add([FromBody] Rent Rent) 
        {
            DB_RENTS.Add(Rent);
            return Rent;
        }


        [HttpPut("")]
        public Rent Update([FromBody] Rent Rent) 
        {
            var currentValue = DB_RENTS.FirstOrDefault(_ => _.Id == Rent.Id);
            if(currentValue != null)
            {
                currentValue.CostumerId = Rent.CostumerId;
                currentValue.VehicleId = Rent.VehicleId;
                currentValue.DtEnd = Rent.DtEnd;
                currentValue.DtBegin = Rent.DtBegin;
            }
            return Rent;
        }
        
        [HttpDelete("{id}")]
        public string Delete(Guid id) 
        {
            var currentValue = DB_RENTS.FirstOrDefault(_ => _.Id == id);
            if(currentValue != null)
            {
                DB_RENTS.Remove(currentValue);
            }
            else
            {
                return $"item {id} nao encontrado";
            }
            return $"{id} removido!";
        }

        [HttpGet("GetAvailableCars")]
        public List<Vehicle> GetAvailableCars(DateTime dtBegin, DateTime dtEnd, EVehicleType type)
        {
            var cars = VehicleController.DB_VEHICLES.Where(_ => _.Type == type);
            var items = DB_RENTS.Where(_ => (_.DtBegin < dtBegin && dtEnd <= _.DtBegin) || (_.DtEnd <= dtBegin && dtEnd <= _.DtEnd)).ToList();

            return cars.Where(c => items.Any(_ => _.VehicleId == c.Id)).ToList();
        }


    }
}