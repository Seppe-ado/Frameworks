namespace Frameworks.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }

        public DateTime Deleted { get; set; } = DateTime.MaxValue;

        public List<ProgresLoc>? ProgresesLoc { get; set; }
    }
}
