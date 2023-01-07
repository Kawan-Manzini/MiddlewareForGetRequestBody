namespace AluCarWepApi.Models
{
    public class Rent : Entity
    {
        public DateTime DtBegin { get; set; }
        public DateTime DtEnd { get; set; }
        public Guid CostumerId { get; set; }
        public Guid VehicleId { get; set; }
    }
}
