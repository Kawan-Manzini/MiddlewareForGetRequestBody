using AluCarWepApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AluCarWepApi.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class FleetController : ControllerBase
    {
        public static List<Fleet> DB_FleetS { get; set; } = new List<Fleet>();
        public FleetController() { }

        [HttpGet("")]
        public List<Fleet> GetAll()
        {
            return DB_FleetS;
        }


        [HttpGet("{id}")]
        public Fleet GetAll(Guid id)
        {
            return DB_FleetS.FirstOrDefault(_ => _.Id == id);
        }

        [HttpPost("")]
        public Fleet Add([FromBody] Fleet Fleet) 
        {
            DB_FleetS.Add(Fleet);
            return Fleet;
        }


        [HttpPut("")]
        public Fleet Update([FromBody] Fleet Fleet) 
        {
            var curFleetValue = DB_FleetS.FirstOrDefault(_ => _.Id == Fleet.Id);
            if(curFleetValue != null)
            {
                curFleetValue.Name = Fleet.Name;
            }
            return Fleet;
        }
        
        [HttpDelete("{id}")]
        public string Delete(Guid id) 
        {
            var curFleetValue = DB_FleetS.FirstOrDefault(_ => _.Id == id);
            if(curFleetValue != null)
            {
                DB_FleetS.Remove(curFleetValue);
            }
            else
            {
                return $"item {id} nao encontrado";
            }
            return $"{id} removido!";
        }



    }
}