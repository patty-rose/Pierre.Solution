using System;
using System.ComponentModel.DataAnnotations;

namespace Pierre.Models
{
  public class Cart
  {
    public int CartId {get; set;}
    public int FlavorTreatId {get; set;}
    public string UserId {get; set;}

    public virtual ApplicationUser User {get; set;}
    public virtual FlavorTreat FlavorTreat {get; set;}
  }
}