using Microsoft.AspNetCore.Mvc;
using ConsoleTest.Models;
using System;
using Microsoft.AspNetCore.JsonPatch;
using ConsoleTest.Services;

namespace ConsoleTest.Controllers;
[ApiController]
[Route("api/Desks")]
public class DeskBookingController : ControllerBase
{

    private readonly ILogger<DeskBookingController> _logger;
    private readonly IMailService _mailService;

    public DeskBookingController(ILogger<DeskBookingController> logger, IMailService mailService)
    {
        //Container can be replaced with any other container we want to use. 
        _logger = logger ?? throw new ArgumentException(nameof(logger));
        //Injecting localMailService 
        _mailService = _mailService ?? throw new ArgumentNullException(nameof(mailService));
    }


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

            _logger.LogInformation($"The booking id {id} wasn'r found when accessing dessk");
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

    //CREATE
    [HttpPost]
    public ActionResult<BookingStatusDto> CreatePointOfInterest(
         int deskId,
         [FromBody] BookingStatusCreateDto bookingStatusCreateDto)
    {
        var desk = DesksStore.Current.Desks.FirstOrDefault(c => c.Id == deskId);
        if (desk == null)
        {
            return NotFound();
        }

        // demo purposes - to be improved
        var maxBookingStatus = DesksStore.Current.Desks.SelectMany(
                         c => c.BookingStatus).Max(p => p.Id);

        var finalBookingStatus = new BookingStatusDto()
        {
            //Takes the pervious ID and then plus one 
            Id = ++maxBookingStatus,
            Name = bookingStatusCreateDto.Name,
            Description = bookingStatusCreateDto.Description
        };

        desk.BookingStatus.Add(finalBookingStatus);

        //CHECK CREATEDATROUTE SINCE IT MIGHT NOT WORK
        //Allows us to return a response with the new return header
        return CreatedAtRoute("GetBookingStatus",
             new
             {
                 deskID = deskId,
                 deskBookingId = finalBookingStatus.Id
             },
             finalBookingStatus);
    }


    // Fully Update a desk booking
    [HttpPut("{deskbookingid}")]
    public ActionResult UpdateDeskBooking(int deskId, int deskBookingtId,
             BookingStatusUpdateDto deskbookingUpdateDto)
    {
        var desk = DesksStore.Current.Desks
            .FirstOrDefault(c => c.Id == deskId);
        if (desk == null)
        {
            return NotFound();
        }

        // find desk booking
        var deskBookingtFromStore = desk.BookingStatus
            .FirstOrDefault(c => c.Id == deskBookingtId);
        if (deskBookingtFromStore == null)
        {
            return NotFound();
        }

        deskBookingtFromStore.Name = deskbookingUpdateDto.Name;
        deskBookingtFromStore.Description = deskbookingUpdateDto.Description;

        return NoContent();
    }

    //Partially Update a desk booking
    [HttpPatch("{deskbookingid}")]
    public ActionResult PartiallyUpdateDeskBooking(
            int deskId, int bookingStatustId,
            JsonPatchDocument<BookingStatusUpdateDto> patchDocument)
    {
        //Finding the desk
        var desk = DesksStore.Current.Desks
            .FirstOrDefault(c => c.Id == deskId);
        if (desk == null)
        {
            return NotFound();
        }

        //Finding the booking status id
        var deskBookingFromStore = desk.BookingStatus
            .FirstOrDefault(c => c.Id == bookingStatustId);
        if (deskBookingFromStore == null)
        {
            return NotFound();
        }
        //Getting the two fields that the is passed in through the query
        var deskBookingtToPatch =
               new BookingStatusUpdateDto()
               {
                   Name = deskBookingFromStore.Name,
                   Description = deskBookingFromStore.Description
               };

        //THe controller base method that takes the object we are patching to as the first parameter 
        // With the validation method as the second.
        //Any errors in this state will amke ModelState invalid. 
        patchDocument.ApplyTo(deskBookingtToPatch, ModelState);

        //Manually Checking before sending off.
        //Model state is a dictionary. Containing the state of the model(DTO) and model binding validation 
        //Also contains a set of error messages.
        //Checks automatically.
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        //
        if (!TryValidateModel(deskBookingtToPatch))
        {
            return BadRequest(ModelState);
        }
        //The rest is the same as pre
        deskBookingFromStore.Name = deskBookingtToPatch.Name;
        deskBookingFromStore.Description = deskBookingtToPatch.Description;

        return NoContent();
    }
    //Deleting Desk Booking
    [HttpDelete("{bookingStatusId}")]
    public ActionResult Delete(int deskId, int bookingStatusId)
    {
        var desk = DesksStore.Current.Desks
            .FirstOrDefault(c => c.Id == deskId);
        if (desk == null)
        {
            return NotFound();
        }

        var deskBookingFromStore = desk.BookingStatus
            .FirstOrDefault(c => c.Id == bookingStatusId);
        if (deskBookingFromStore == null)
        {
            return NotFound();
        }

        //implimenting a mock email service 
        desk.BookingStatus.Remove(deskBookingFromStore);
        _mailService.Send("Booking Deleted. ",
        $"Desk Booking {deskBookingFromStore.Name} with id {bookingStatusId} was deleted");


        return NoContent();
    }
}






