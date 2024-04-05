using BookAVacation.Interfaces;
using BookAVacation.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookAVacation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public IActionResult CreateReservation([FromQuery] int propertyId, [FromBody] Reservation reservationCreate)
        {
            if (reservationCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_reservationRepository.CreateReservation(reservationCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving the reservation.");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created.");
        }
    }
}
