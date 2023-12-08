using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Frameworks.Data;
using Frameworks.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Frameworks.Areas.Identity.Data;

// Add profile data for application users by adding properties to the FrameworksUser class
public class FrameworksUser : IdentityUser
{

    public String FirstName { get; set; }
    public String LastName { get; set; }

    public List<Progres>? ProgresesUser { get; set; } 
    public List<ProgresLoc>? ProgresesUserLoc { get; set; } 

}

