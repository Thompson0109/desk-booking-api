using System.ComponentModel.DataAnnotations;

namespace ConsoleTest.Models;

public class BookingStatusCreateDto
{

    [Required]
    [MaxLength(4)]
    public Int16 Id { get; set; }

    [Required(ErrorMessage = "You need to provide a Desk Number")]
    [MaxLength(4)]
    public Int16 DeskNumber { get; set; }
    //Strings need to be set to a value of empty if not nullable
    [MaxLength(200)]
    public string? Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime DateBooked { get; } = DateTime.Now;
    public DateTime? DateUpdated { get; set; }

}