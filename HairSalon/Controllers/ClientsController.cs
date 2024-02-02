using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    public ActionResult Create()
    {
        ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
        return View();
    }


    [HttpPost]
    public ActionResult Create(Client client)
    {
        if (client.StylistId == 0)
        {
            return RedirectToAction("create");
        }
        _db.Clients.Add(client);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}