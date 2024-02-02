using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers;

public class ClientsController : Controller
{
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Client> model = _db.Clients
            .Include(client => client.Stylist)
            .ToList();
        ViewBag.PageTitle = "View all clients";
        return View(model);
    }
}