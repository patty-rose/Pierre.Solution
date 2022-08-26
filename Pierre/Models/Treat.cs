using Microsoft.AspNetCore.Authorization;//to use [AllowAnonymous] and roles
using System.Collections.Generic;
using System;

namespace Pierre.Models
{
  public class Treat
  {

    public Treat()
      {
          this.JoinEntities = new HashSet<FlavorTreat>();
      }
      
    public int TreatId { get; set; }  
    
    public string Title { get; set; }

    public virtual ICollection<FlavorTreat> JoinEntities { get; } 
  }
}