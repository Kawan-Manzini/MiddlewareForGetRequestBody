using AluCarWepApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AluCarWepApi.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        public static List<Store> DB_StoreS { get; set; } = new List<Store>();
        public StoreController() { }

        [HttpGet("")]
        public List<Store> GetAll()
        {
            return DB_StoreS;
        }


        [HttpGet("{id}")]
        public Store GetAll(Guid id)
        {
            return DB_StoreS.FirstOrDefault(_ => _.Id == id);
        }

        [HttpPost("createStore")]
        public Store Add([FromBody] Store Store) 
        {
            DB_StoreS.Add(Store);
            return Store;
        }


        [HttpPut("")]
        public Store Update([FromBody] Store Store) 
        {
            var curStoreValue = DB_StoreS.FirstOrDefault(_ => _.Id == Store.Id);
            if(curStoreValue != null)
            {   
                curStoreValue.CNPJ = Store.CNPJ;
                curStoreValue.Name = Store.Name;
                curStoreValue.ZipCode = Store.ZipCode;
            }
            return Store;
        }
        
        [HttpDelete("{id}")]
        public string Delete(Guid id) 
        {
            var curStoreValue = DB_StoreS.FirstOrDefault(_ => _.Id == id);
            if(curStoreValue != null)
            {
                DB_StoreS.Remove(curStoreValue);
            }
            else
            {
                return $"item {id} nao encontrado";
            }
            return $"{id} removido!";
        }



    }
}