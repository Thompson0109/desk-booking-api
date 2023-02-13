namespace ConsoleTest.Models{


    public class Desk{
        public int Id { get; set; }
        public int DeskNumber { get; set; }
         public bool isAvailable { get; set; } = false;

            public ICollection<BookingStatusDto> BookingStatus {get; set;}
                = new List<BookingStatusDto>();
    }
}