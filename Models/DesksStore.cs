
namespace ConsoleTest.Models;
public class DesksStore
{
    public List<Desk> Desks { get; set; }
    public BookingStatusDto bookingStatus { get; set; }
    public List<BookingStatusDto>? DeskBookingStatusList { get; set; }
    public static DesksStore Current { get; } = new DesksStore();

    public DesksStore()
    {
        //init dummy data
        Desks = new List<Desk>()
                    {
                        new Desk(){
                            Id = 1,
                            DeskNumber = 38,
                            BookingStatus = new List<BookingStatusDto>(){
                                     new BookingStatusDto(){
                                            Id  = 1,
                                            DeskNumber = 49,
                                            Name = "John Smith",
                                            Description = "Ello",
                                            DateBooked =  Convert.ToDateTime("10/08/2023 12:10:15 PM"),
                                            DateUpdated  = Convert.ToDateTime("09/08/2023 12:10:15 PM"),
                                        },

                                          new BookingStatusDto(){
                                            Id  = 2,
                                            DeskNumber = 49,
                                            Name = "John Smith",
                                            Description = "I need this",
                                            DateBooked =  Convert.ToDateTime("11/08/2023 12:10:15 PM"),
                                            DateUpdated  = Convert.ToDateTime("10/08/2023 12:10:15 PM"),
                                    },
                            }
                        },
                        new Desk(){
                            Id = 2,
                            DeskNumber = 39,
                           BookingStatus = new List<BookingStatusDto>(){}

                        },
                        new Desk(){
                        Id = 3,
                        DeskNumber = 49,
                        },
                            new Desk(){
                            Id = 3,
                            DeskNumber = 49,

                                BookingStatus = new List<BookingStatusDto>(){

                                    new BookingStatusDto(){
                                            Id  = 1,
                                            DeskNumber = 49,
                                            Name = "Louis Thompson",
                                            Description = "I need this on Tuesday",
                                            DateBooked =  Convert.ToDateTime("10/08/2023 12:10:15 PM"),
                                            DateUpdated  = Convert.ToDateTime("09/08/2023 12:10:15 PM"),
                                        },

                                          new BookingStatusDto(){
                                            Id  = 2,
                                            DeskNumber = 49,
                                            Name = "Louis Thompson",
                                            Description = "I need this on Tuesday",
                                            DateBooked =  Convert.ToDateTime("11/08/2023 12:10:15 PM"),
                                            DateUpdated  = Convert.ToDateTime("10/08/2023 12:10:15 PM"),
                                    },
                                          new BookingStatusDto(){
                                            Id  = 3,
                                            DeskNumber = 49,
                                            Name = "Louis Thompson",
                                            Description = "I need this on Tuesday",
                                            DateBooked =  Convert.ToDateTime("12/08/2023 12:10:15 PM"),
                                            DateUpdated  = Convert.ToDateTime("09/08/2023 12:10:15 PM"),
                                    },
                                          new BookingStatusDto(){
                                            Id  = 4,
                                            DeskNumber = 49,
                                            Name = "John Smith",
                                            Description = "I need this on Friday",
                                            DateBooked =  Convert.ToDateTime("13/08/2023 12:10:15 PM"),
                                            DateUpdated  = Convert.ToDateTime("11/08/2023 12:10:15 PM"),
                                    },
                                }
                    }
            };
    }
}
