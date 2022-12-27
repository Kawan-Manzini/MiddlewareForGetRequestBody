using AluCarWepApi.Enums;

namespace AluCarWepApi.Models
{
    public class Fleet : Entity
    {
        public int Capacity { get; set; }
        public string Name { get; set; }
        public ECarModel FleetModel { get; set; }

        public Fleet(int capacity, string name, ECarModel fleetModel)
        {
            Capacity = capacity;
            Name = name;
            FleetModel = fleetModel;
        }
    }
}
