using Frameworks.Areas.Identity.Data;
using Frameworks.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Frameworks.Data;

public class FrameworksContext : IdentityDbContext<FrameworksUser>
{
    public FrameworksContext(DbContextOptions<FrameworksContext> options)
        : base(options)
    {
    }

    
    public DbSet<Frameworks.Models.Progres> Progres { get; set; }
    public DbSet<Frameworks.Models.Route> Routes { get; set; }
    public DbSet<Frameworks.Models.Location> Locations { get; set; }
    public DbSet<Frameworks.Models.ProgresLoc> ProgresLocs { get; set; }


    public static async Task DataInitializer(FrameworksContext context)
    {
        if (!context.Users.Any())
        {
            FrameworksUser dummyuser = new FrameworksUser
            {
                Id = "1",
                Email = "user1@email.com",
                UserName = "User1",
                FirstName = "User",
                LastName = "1",
                PasswordHash = "test",
                LockoutEnabled = true,
                LockoutEnd = DateTime.MaxValue
                
            };
            context.Users.Add(dummyuser);
            context.SaveChanges();
        }
        if (!context.Routes.Any())
        {
            context.Add(new Models.Route { Name = "Route1", Description = "Route1Description", Length = 5, Duration = 65 });
            context.Add(new Models.Route { Name = "Route2", Description = "Route2Description", Length = 6, Duration = 80 });
            context.Add(new Models.Route { Name = "Route3", Description = "Route3Description", Length = 7, Duration = 90 });
            context.Add(new Models.Route { Name = "Route4", Description = "Route4Description", Length = 8, Duration = 110 });
            context.Add(new Models.Route { Name = "Route5", Description = "Route5Description", Length = 9, Duration = 130 });
            context.SaveChanges();
        }
        if (!context.Locations.Any())
        {
            context.Add(new Models.Location { Name = "Location1", Description = "Location1Description", Adress="Adress1" });
            context.Add(new Models.Location { Name = "Location2", Description = "Location2Description", Adress = "Adress2" });
            context.Add(new Models.Location { Name = "Location3", Description = "Location3Description", Adress = "Adress3" });
            context.Add(new Models.Location { Name = "Location4", Description = "Location4Description", Adress = "Adress4" });
            context.Add(new Models.Location { Name = "Location5", Description = "Location5Description", Adress = "Adress5" });
            context.SaveChanges();
        }
        if (!context.Progres.Any())
        {
            context.Add(new Progres { Comment = "Comment1", Completed = true, DateTime = DateTime.Now, RouteId = 1, FrameworksUserId = "1" });
            context.Add(new Progres { Comment = "Comment2", Completed = true, DateTime = DateTime.Now, RouteId = 2, FrameworksUserId = "1" });
            context.Add(new Progres { Comment = "Comment3", Completed = true, DateTime = DateTime.Now, RouteId = 3, FrameworksUserId = "1" });
            context.Add(new Progres { Comment = "Comment4", Completed = true, DateTime = DateTime.Now, RouteId = 4, FrameworksUserId = "1" });
            context.SaveChanges();
        }
        if (!context.ProgresLocs.Any())
        {
            context.Add(new ProgresLoc { Comment = "Comment1", Completed = true, DateTime = DateTime.Now, LocationsId = 1, FrameworksUserId = "1" });
            context.Add(new ProgresLoc { Comment = "Comment2", Completed = true, DateTime = DateTime.Now, LocationsId = 2, FrameworksUserId = "1" });
            context.Add(new ProgresLoc { Comment = "Comment3", Completed = true, DateTime = DateTime.Now, LocationsId = 3, FrameworksUserId = "1" });
            context.Add(new ProgresLoc { Comment = "Comment4", Completed = true, DateTime = DateTime.Now, LocationsId = 4, FrameworksUserId = "1" });
            context.SaveChanges();
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    
}
