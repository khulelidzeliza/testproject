

using ConsoleApp12.Enums;

namespace ConsoleApp12.Models;

internal class Booking
{
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public BookingType bookingType { get; set; } = BookingType.Pending;

    public int UserId { get; set; }
    public User User { get; set; }
    public int ServiceId { get; set; }
    public Service Service { get; set; }
}

