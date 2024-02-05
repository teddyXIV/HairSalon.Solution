namespace HairSalon.Models;
using System.ComponentModel.DataAnnotations;


public class Client
{
    public int ClientId { get; set; }
    public string Name { get; set; }
    public int StylistId { get; set; }
    public Stylist Stylist { get; set; }
    public List<Appointment> Appointments { get; set; }
}