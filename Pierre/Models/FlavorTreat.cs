using System.Collections.Generic;

namespace Pierre.Models
{
  public class FlavorTreat
    {       
        public int FlavorTreatId { get; set; }
        public int Price { get; set; }
        public int TreatId { get; set; }
        public int FlavorId { get; set; }
        public virtual Treat Treat { get; set; }
        public virtual Flavor Flavor { get; set; }

        public FlavorTreat()
        {
          this.Price = 0;
        }
    }
}