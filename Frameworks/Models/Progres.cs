using System.ComponentModel.DataAnnotations.Schema;
using Frameworks.Areas.Identity.Data;

namespace Frameworks.Models
{
    public class Progres
    {
        public int Id { get; set; }
        [ForeignKey("Route")]
        public int RouteId { get; set; }
        [ForeignKey("FrameworksUser")]
        public string FrameworksUserId { get; set; }

        public string Comment { get; set; }
        public Boolean Completed { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        public DateTime Deleted { get; set; } = DateTime.MaxValue;

        public FrameworksUser? Users { get; set; }
        public Route? Route { get; set; }
    }
}
