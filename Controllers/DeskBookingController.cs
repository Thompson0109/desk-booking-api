using Microsoft.AspNetCore.Mvc;
using ConsoleTest.Models;

namespace ConsoleTest.Controllers;



    [ApiController]
    [Route("api/DeskBooking")]
        public class DeskBookingController : ControllerBase
        {
            [HttpGet]
            public JsonResult GetDeskbookings(){
                return new JsonResult(DeskBookingStore.Current.DeskBookings);
            }

            [HttpGet("{id}")]
            public ActionResult<DeskBookingDto> GetDeskBooking(int id){
            var bookingToReturn =  DeskBookingStore.Current.DeskBookings.FirstOrDefault(c => c.Id == id);

            if(bookingToReturn == null){
                return NotFound();
            }
            return Ok(bookingToReturn);

            }
        }

