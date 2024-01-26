using Frameworks.Areas.Identity.Data;
using Frameworks.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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


    public static async Task DataInitializer(FrameworksContext context, UserManager<FrameworksUser> userManager)
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
                LockoutEnd = DateTime.MaxValue,
                EmailConfirmed = true
                
            };
            FrameworksUser dummyuser2 = new FrameworksUser
            {
                Id = "2",
                Email = "user1@email.com",
                UserName = "User2",
                FirstName = "User",
                LastName = "2",
                PasswordHash = "test",
                LockoutEnabled = true,
                LockoutEnd = DateTime.MaxValue,
                EmailConfirmed = true

            };
            context.Users.Add(dummyuser);
            
            context.SaveChanges();
            var result2 = await userManager.CreateAsync(dummyuser2, "Testing1%");
            FrameworksUser adminUser = new FrameworksUser
            {
                Id = "3",
                Email = "admin@gmail.com",
                UserName = "Admin",
                FirstName = "Admin",
                LastName = "Test",
                EmailConfirmed = true

            };
            var result= await userManager.CreateAsync(adminUser,"Testing1%");
        }

        FrameworksUser dummy= context.Users.First(p=>p.UserName =="User1");
        FrameworksUser dummy2 = context.Users.First(p => p.UserName == "User2");
        FrameworksUser admin = context.Users.First(p => p.UserName == "Admin");
        

        
        if (!context.Roles.Any())
        {
            context.Roles.AddRange(
                new IdentityRole { Name = "SystemAdministrator", Id = "SystemAdministrator", NormalizedName = "SYSTEMADMINISTRATOR" },
                new IdentityRole { Name = "User", Id = "User", NormalizedName = "USER" }
                
            );

            context.UserRoles.Add(new IdentityUserRole<string> { RoleId = "SystemAdministrator", UserId = admin.Id });
            context.UserRoles.Add(new IdentityUserRole<string> { RoleId = "User", UserId = dummy.Id });
            context.UserRoles.Add(new IdentityUserRole<string> { RoleId = "User", UserId = dummy2.Id });


            context.SaveChanges();
        }
        if (!context.Routes.Any())
        {
            context.Add(new Models.Route { Name = "Sentier des Sables", Description = "Through the woods", Length = 10, Duration = 3 });
            context.Add(new Models.Route { Name = "Brussels Green Walk", Description = "Loop through brussels", Length = 59, Duration = 15 });
            context.Add(new Models.Route { Name = "Red Monastry", Description = "Viscinity of brussels", Length = 7, Duration = 2 });
            context.Add(new Models.Route { Name = "Sonian Forest", Description = "Trail through the sonian Forest", Length = 20, Duration = 5 });
            context.Add(new Models.Route { Name = "Culture and Arts Tour", Description = "Heart of Brussels", Length = 5, Duration = 2 });
            context.SaveChanges();
        }
        if (!context.Locations.Any())
        {
            context.Add(new Models.Location { Name = "Grand Place", Description = "The beating heart of brussels night life.", Adress= "Grand Place Brussels Main Square, Brussels 1000 Belgium" });
            context.Add(new Models.Location { Name = "Les Galeries Royales", Description = "Decadence and beauty", Adress = "Galerie du Roi 5 Galeries Royales Saint-Hubert, Brussels 1000 Belgium" });
            context.Add(new Models.Location { Name = "Atomium", Description = "A classic belgian monument.", Adress = "Atomium Square Laeken, Brussels 1020 Belgium" });
            context.Add(new Models.Location { Name = "Mini-Europe", Description = "Europe but tiny", Adress = "Bruparck, Brussels 1020 Belgium" });
            context.Add(new Models.Location { Name = "Parc du Cinquantenaire", Description = "Beautiful park in the center of brussels.", Adress = "Avenue de la Renaissance 1000 Brussels, Belgium, Brussels 1000 Belgium" });
            context.SaveChanges();
        }
        if (!context.Progres.Any())
        {
            context.Add(new Progres { Comment = "Such a nice forest with so much history!", Completed = true, DateTime = DateTime.Now, RouteId = 1, FrameworksUserId = "3" });
            context.Add(new Progres { Comment = "Definitely a route to split up", Completed = true, DateTime = DateTime.Now, RouteId = 2, FrameworksUserId = "3" });
            context.Add(new Progres { Comment = "A beautiful monastry", Completed = true, DateTime = DateTime.Now, RouteId = 3, FrameworksUserId = "3" });
            context.Add(new Progres { Comment = "A stunning forest", Completed = true, DateTime = DateTime.Now, RouteId = 4, FrameworksUserId = "3" });
            context.SaveChanges();
        }
        if (!context.ProgresLocs.Any())
        {
            context.Add(new ProgresLoc { Comment = "A wonderful place both day and night", Completed = true, DateTime = DateTime.Now, LocationsId = 1, FrameworksUserId = "3" });
            context.Add(new ProgresLoc { Comment = "Such beautiful lighting, but expensive stores.", Completed = true, DateTime = DateTime.Now, LocationsId = 2, FrameworksUserId = "3" });
            context.Add(new ProgresLoc { Comment = "Even bigger than on the picture", Completed = true, DateTime = DateTime.Now, LocationsId = 3, FrameworksUserId = "3" });
            context.Add(new ProgresLoc { Comment = "Crazy to see things so small.", Completed = true, DateTime = DateTime.Now, LocationsId = 4, FrameworksUserId = "3" });
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
    static void AddParameters(FrameworksContext context, FrameworksUser user)
    {

    }

public DbSet<Frameworks.Models.Language> Language { get; set; } = default!;
    
}
