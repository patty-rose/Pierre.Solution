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
  public class TreatsController : Controller
  {
    private readonly PierreContext _db;

    private readonly UserManager<ApplicationUser> _userManager;

    private readonly ILogger<TreatsController> _logger;

    public TreatsController(UserManager<ApplicationUser> userManager, PierreContext db, ILogger<TreatsController> logger)
    {
      _userManager = userManager;
      _db = db;
      _logger = logger;
    }

    public ActionResult Index()
    {
      List<Treat> model = _db.Treats.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Treat treat, int FlavorId)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();
      if (FlavorId != 0)
      {
        _db.FlavorTreat.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisTreat = _db.Treats.Include(treat => treat.JoinEntities).ThenInclude(join => join.Flavor).FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    public ActionResult Edit(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Entry(treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFlavor(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int FlavorId)
    {
      if (FlavorId != 0 && !_db.FlavorTreat.Any(model=> model.FlavorId == FlavorId && model.TreatId == treat.TreatId))
      {
        _db.FlavorTreat.Add(new FlavorTreat() { TreatId = treat.TreatId, FlavorId = FlavorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteFlavor(int joinId)
    {
      var joinEntry = _db.FlavorTreat.FirstOrDefault(entry => entry.FlavorTreatId == joinId);
      _db.FlavorTreat.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    //cart routes
    public async Task<ActionResult> FlavorTreatUser()
    {

      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);

      var flavorTreatUser = _db.ApplicationUsers
        .Include(user=> user.JoinFlavorTreatUser)
        .ThenInclude(join=>join.FlavorTreat)

        .FirstOrDefault(user=>user.Id == currentUser.Id);
      return View(flavorTreatUser);

    }

    public ActionResult AddTreatToCart(int id)
    {
      var thisFlavorTreat = _db.FlavorTreat.FirstOrDefault(flavorTreat => flavorTreat.FlavorTreatId ==id);
      return View(thisFlavorTreat);
    }

    [HttpPost]
    public ActionResult AddTreatToCart(FlavorTreat flavorTreat)
    {
      var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (UserId != null && !_db.FlavorTreatUser.Any(model => model.FlavorTreatId == flavorTreat.FlavorTreatId && model.UserId == UserId))
      {
        _db.FlavorTreatUser.Add(new Models.FlavorTreatUser() {UserId = UserId, FlavorTreatId = flavorTreat.FlavorTreatId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}