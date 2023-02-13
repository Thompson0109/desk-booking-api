namespace ConsoleTest.Models;

public class BookingStatusDto{
        public int Id { get; set; }
        public int  DeskNumber { get; set; }
        //Strings need to be set to a value of empty if not nullable
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime DateBooked {get; set;}
        public DateTime DateUpdated {get; set;}

}