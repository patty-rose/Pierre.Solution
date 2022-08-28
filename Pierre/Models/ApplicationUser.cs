using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pierre.Models
{
  public class ApplicationUser : IdentityUser
  {
    public virtual FlavorTreat FlavorTreat {get; set;}
    public virtual ICollection<FlavorTreatUser> JoinFlavorTreatUser {get;}
  }
}