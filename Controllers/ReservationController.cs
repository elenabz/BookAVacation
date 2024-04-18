using AutoMapper;
using BookAVacation.DTO;
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
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        public ReservationController(IReservationRepository reservationRepository, IPropertyRepository propertyRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        [HttpGet("{propertyId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DateTime>))]
        [ProducesResponseType(404)]
        public IActionResult GetPropertyReservations(int propertyId)
        {
            if(propertyId < 1)
            {
                return BadRequest(ModelState);
            }
            return Ok(_reservationRepository.GetPropertyReservations(propertyId));
        }

        [HttpPost("{propertyId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public IActionResult CreateReservation(int propertyId, [FromBody] ReservationDto reservationCreate)
        {
            if (!_propertyRepository.PropertyExists(propertyId))
            {
                return NotFound();
            }
            if (reservationCreate == null)
            {
                return BadRequest(ModelState);
            }

            Console.WriteLine(default(DateTime));

            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var reservationMap = _mapper.Map<Reservation>(reservationCreate);

            if (!_reservationRepository.CreateReservation(propertyId, reservationMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving the reservation.");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created.");
        }
    }
}
