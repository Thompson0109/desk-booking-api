namespace ConsoleTest.Models{

    public class DeskBookingDto{
        public int Id { get; set; }
        //Strings need to be set to a value of empty if not nullable
        public string Name { get; set; } = string.Empty;
        public int DeskNumber { get; set; }
        public string? Description { get; set; }
        public ICollection<BookingStatusDto> BookingStatus {get; set;}
                = new List<BookingStatusDto>();
    }
}
