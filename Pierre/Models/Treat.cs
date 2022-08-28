using Microsoft.AspNetCore.Authorization;//to use [AllowAnonymous] and roles
using System.Collections.Generic;
using System;

namespace Pierre.Models
{
  public class Treat
  {
    public int TreatId { get; set; }  
    
    public string Type { get; set; }

    public int Price { get; set; }

    public virtual ICollection<FlavorTreat> JoinEntities { get; } 

    public Treat()
      {
          this.JoinEntities = new HashSet<FlavorTreat>();
          this.Price = 0;
      }
  }
}