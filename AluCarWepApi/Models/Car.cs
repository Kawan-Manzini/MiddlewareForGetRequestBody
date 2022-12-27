namespace AluCarWepApi.Models
{
    public class Car : Entity
    {
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public int KmRotated { get; set; }
        public int BoardEnd { get; set; }
        public bool IsRented { get; set; } = false;
        public DateTime RentalDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public virtual Fleet Fleet { get; set; }
        public Guid FleetId { get; set; }

        public Car(string name, DateTime year, int kmRotated, int boardEnd, bool isRented, DateTime rentalDate, DateTime deliveryDate)
        {
            Name = name;
            Year = year;
            KmRotated = kmRotated;
            BoardEnd = boardEnd;
            IsRented = isRented;
            RentalDate = rentalDate;
            DeliveryDate = deliveryDate;
        }
    }
}
