using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers;

public class SearchController : Controller
{
    private readonly HairSalonContext _db;
    public SearchController(HairSalonContext db)
    {
        _db = db;
    }

    public async Task<ActionResult> Index(string searchType, string searchTerm)
    {
        switch (searchType)
        {
            case "client":
                List<Client> clientResults = await _db.Clients
                    .Where(client => client.Name.Contains(searchTerm))
                    .Include(client => client.Stylist)
                    .ToListAsync();
                return View(clientResults);
            default:
                List<Stylist> stylistResults = await _db.Stylists
                    .Where(stylist => stylist.Name.Contains(searchTerm))
                    .ToListAsync();
                return View(stylistResults);
        }
    }
}