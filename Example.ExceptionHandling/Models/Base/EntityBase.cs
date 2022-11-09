namespace Example.ExceptionHandling.Models.Base
{
    public class EntityBase
    {
        public EntityBase()
        {
            CreatedAt = DateTime.Now;
            EditedAt = DateTime.Now;
        }

        public Guid Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; }
        public Guid EditedBy { get; set; }
        public DateTime EditedAt { get; set; }
    }
}