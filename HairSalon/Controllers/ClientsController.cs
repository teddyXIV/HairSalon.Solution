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
        ViewBag.PageTitle = "All clients";
        return View(model);
    }

    public ActionResult Create()
    {
        ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
        ViewBag.PageTitle = "Add a client";
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

    public ActionResult Details(int id)
    {
        Client client = _db.Clients.Include(client => client.Stylist).FirstOrDefault(client => client.ClientId == id);
        ViewBag.PageTitle = "Client details";
        return View(client);
    }

    public ActionResult Edit(int id)
    {
        Client client = _db.Clients.FirstOrDefault(client => client.ClientId == id);
        ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
        ViewBag.PageTitle = "Edit client info";
        return View(client);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
        _db.Clients.Update(client);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        Client client = _db.Clients.FirstOrDefault(client => client.ClientId == id);
        ViewBag.PageTitle = "Remove client";
        return View(client);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult ConfirmDelete(int id)
    {
        Client client = _db.Clients.FirstOrDefault(client => client.ClientId == id);
        _db.Clients.Remove(client);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}