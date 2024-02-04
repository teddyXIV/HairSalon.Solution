using System.ComponentModel.DataAnnotations;

namespace HairSalon.Models;

public class Appointment
{
    public int AppointmentId { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
}