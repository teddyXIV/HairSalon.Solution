using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers;

public class AppointmentsController : Controller
{
    private readonly HairSalonContext _db;

    public AppointmentsController(HairSalonContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Appointment> model = _db.Appointments
            .Include(appointment => appointment.Client)
            .ThenInclude(client => client.Stylist)
            .ToList();
        ViewBag.PageTitle = "All appointments";
        return View(model);
    }

    public ActionResult Create()
    {
        ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "Name");
        ViewBag.PageTitle = "Add an appointment";
        return View();
    }

    [HttpPost]
    public ActionResult Create(Appointment appointment)
    {
        if (appointment.ClientId == 0)
        {
            return RedirectToAction("create");
        }

        List<Appointment> conflictCheck = _db.Appointments
            .Where(a => a.ClientId == appointment.ClientId)
            .ToList();

        if (conflictCheck.Any(a => a.Time == appointment.Time) && conflictCheck.Any(a => a.Date == appointment.Date))
        {
            return RedirectToAction("create");
        }
        _db.Appointments.Add(appointment);
        _db.SaveChanges();
        return RedirectToAction("index");
    }

    public ActionResult Delete(int id)
    {
        Appointment appt = _db.Appointments.FirstOrDefault(appt => appt.AppointmentId == id);
        ViewBag.PageTitle = "Cancel appointment";
        ViewBag.Details = appt;
        ViewBag.Client = _db.Clients.FirstOrDefault(client => client.ClientId == appt.ClientId);
        return View(appt);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult ConfirmDelete(int id)
    {
        Appointment appt = _db.Appointments.FirstOrDefault(appt => appt.AppointmentId == id);
        _db.Appointments.Remove(appt);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}