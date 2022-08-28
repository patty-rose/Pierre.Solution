using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Pierre.Models;
using Microsoft.Extensions.Logging;

namespace Pierre.Controllers
{
  public class FlavorTreatsController : Controller
  {
    private readonly PierreContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<FlavorTreatsController> _logger;

    public FlavorTreatsController(UserManager<ApplicationUser> userManager, PierreContext db, ILogger<FlavorTreatsController> logger)
    {
      _userManager = userManager;
      _db = db;
      _logger = logger;
    }

    public ActionResult AddFlavorTreatPrice(int id)
    {
      var joinItem = _db.FlavorTreat.FirstOrDefault(entry => entry.FlavorTreatId == id);
      _logger.LogInformation(id.ToString());
      return View(joinItem);
    }

    [HttpPost]
    public ActionResult AddFlavorTreatPrice(FlavorTreat flavorTreat)
    {
      
      _db.Entry(flavorTreat).State = EntityState.Modified;
      _db.SaveChanges();

      _logger.LogInformation(flavorTreat.Price.ToString());

      return RedirectToAction("Index", "Home");
    }
  }
}
