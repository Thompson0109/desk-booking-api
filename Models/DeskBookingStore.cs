namespace ConsoleTest.Models{

    public class DeskBookingStore{
        public List<DeskBookingDto> DeskBookings { get; set; }
        public static DeskBookingStore Current {get; } = new DeskBookingStore();


        public DeskBookingStore(){

            //init dummy data
                    DeskBookings = new List<DeskBookingDto>()
                    {
                        new DeskBookingDto(){
                            Id = 1,
                        Name = "Louis Thompson",
                        DeskNumber = 38,
                        Description = ""  
                        },
                        new DeskBookingDto(){
                            Id = 2,
                            Name = "Jacob Cairncross",
                            DeskNumber = 39,
                        },
                        new DeskBookingDto(){
                        Id = 3, Name = "Dylyan Perve", 
                        DeskNumber = 49,
                        Description = " "
                        },
                        new DeskBookingDto(){
                        Id = 3, Name = "Bozhidar Klouchek", 
                        DeskNumber = 49,
                        Description = " ",

                        BookingStatus = new List<BookingStatusDto>(){
                            new BookingStatusDto(){
                            }
                        }
                        }
                    };
        }
    }
}
