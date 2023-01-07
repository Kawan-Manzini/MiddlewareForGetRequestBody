using AluCarWepApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AluCarWepApi.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class CostumerController : ControllerBase
    {
        public static List<Costumer> DB_CostumerS { get; set; } = new List<Costumer>();
        public CostumerController() { }

        [HttpGet("Costumers")]
        public List<Costumer> GetAll()
        {
            return DB_CostumerS;
        }


        [HttpGet("Costumers/{id}")]
        public Costumer GetAll(Guid id)
        {
            return DB_CostumerS.FirstOrDefault(_ => _.Id == id);
        }

        [HttpPost("Costumers")]
        public Costumer Add([FromBody] Costumer Costumer) 
        {
            DB_CostumerS.Add(Costumer);
            return Costumer;
        }


        [HttpPut("Costumers")]
        public Costumer Update([FromBody] Costumer Costumer) 
        {
            var curCostumerValue = DB_CostumerS.FirstOrDefault(_ => _.Id == Costumer.Id);
            if(curCostumerValue != null)
            {
                curCostumerValue.Cpf = Costumer.Cpf;
                curCostumerValue.Name = Costumer.Name;
            }
            return Costumer;
        }
        
        [HttpDelete("Costumers/{id}")]
        public string Delete(Guid id) 
        {
            var curCostumerValue = DB_CostumerS.FirstOrDefault(_ => _.Id == id);
            if(curCostumerValue != null)
            {
                DB_CostumerS.Remove(curCostumerValue);
            }
            else
            {
                return $"item {id} nao encontrado";
            }
            return $"{id} removido!";
        }



    }
}