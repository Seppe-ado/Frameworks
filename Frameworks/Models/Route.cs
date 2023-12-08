namespace Frameworks.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }
        public int Duration { get; set; }
        public DateTime Deleted { get; set; } = DateTime.MaxValue;

        public List<Progres>? ProgresesRoute { get; set; }

    }
}
