using AluCarWepApi.Enums;

namespace AluCarWepApi.Models
{
    public class Vehicle : Entity
    {
        public string Plate { get; set; }
        public EVehicleType Type { get; set; }
        public Guid StoreId { get; set; }

    }
}
