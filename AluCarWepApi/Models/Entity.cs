namespace AluCarWepApi.Models
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime DeletedAt { get; private set; }
        public bool NonInstance { get; protected set; }
        public bool Excluded { get; set; }
        public Guid InstanceId { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
            var now = DateTime.Now;
            CreatedAt = now;
            UpdatedAt = now;
            DeletedAt = new DateTime(1970, 01, 01);
            Excluded = false;
            NonInstance = false;
        }
    }
}
