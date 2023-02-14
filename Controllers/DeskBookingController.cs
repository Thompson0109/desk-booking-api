using Microsoft.AspNetCore.Mvc;
using ConsoleTest.Models;

namespace ConsoleTest.Controllers;
[ApiController]
[Route("api/Desks")]
public class DeskBookingController : ControllerBase
{
    //All Desk bookings
    [HttpGet("DeskBooking")]
    public ActionResult<IEnumerable<DeskBookingDto>> GetDeskBookings()
    {
        return Ok(DeskBookingStore.Current.DeskBookings);
    }

    //All Desks
    [HttpGet("All")]
    public ActionResult<IEnumerable<Desk>> GetDesks()
    {
        return Ok(DesksStore.Current.Desks);
    }

    //Searches if that Desk Exists
    [HttpGet("DeskBooking/{id}")]
    public ActionResult<DeskBookingDto> GetDeskBooking(int id)
    {
        var bookingToReturn = DeskBookingStore.Current.DeskBookings.Where(c => c.Id == id).FirstOrDefault();

        if (bookingToReturn == null)
        {
            return NotFound();
        }
        return Ok(bookingToReturn);
    }

    //Searches for all bookings under desk
    //https://localhost:7141/api/1/bookingstatus
    [HttpGet("{deskId}/bookingstatus")]
    public ActionResult<IEnumerable<BookingStatusDto>> GetDeskBookingStatuses(int deskId)
    {

        //Searches for all desks that match that ID
        var DeskToReturn = DesksStore.Current.Desks.Where(c => c.Id == deskId);

        if (DeskToReturn == null)
        {
            //If full URI doesn't result in a resource through invalid ID
            return NotFound();
        }
        return Ok(DeskToReturn);
    }

    //Searches for all bookings under desk
    //https://localhost:7141/api/DeskBooking/1/bookingstatus
    [HttpGet("{deskId}/{deskbookingId}")]
    public ActionResult<BookingStatusDto> GetDeskBookingStatus(int deskId, int deskbookingId)
    {

        //First we try and find the Desk
        var DeskToReturn = DesksStore.Current.Desks.FirstOrDefault(c => c.Id == deskId);
        //If full URI doesn't result in a resource through invalid ID
        Console.WriteLine("Getting Hit");
        if (DeskToReturn == null)
        {
            Console.WriteLine(DeskToReturn);
            Console.WriteLine("Broken");

            return NotFound();
        }

        //If Desk Exists, search for DeskBooking ID

        var bookingStatusToReturn = DeskToReturn.BookingStatus.FirstOrDefault(c => c.Id == deskbookingId);

        if (bookingStatusToReturn == null)
        {
            Console.WriteLine("Broken");
            return NotFound("THIS IS BROKEN");
        }

        return Ok(bookingStatusToReturn);

    }
}


