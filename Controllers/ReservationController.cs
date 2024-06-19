using AutoMapper;
using BookAVacation.DTO;
using BookAVacation.Interfaces;
using BookAVacation.Models;
using BookAVacation.Validations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookAVacation.Controllers
{
    [Authorize]
    [ApiController] // no need to add !ModelState.IsValid && [FromBody] [FromRoute]
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
        public IActionResult CreateReservation(int propertyId, ReservationDto reservationCreate)
        {
            var v = new CreateReservationRequestValidator();
            ValidationResult validationResult = v.Validate(reservationCreate);
            if (!validationResult.IsValid)
            {
                var modelStateDictionary = new ModelStateDictionary();
                foreach(ValidationFailure failure in validationResult.Errors)
                {
                    modelStateDictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
                }
                return ValidationProblem(modelStateDictionary);

            }
            if (!_propertyRepository.PropertyExists(propertyId))
            {
                return NotFound();
            }
            if (reservationCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ValidatePeriod(reservationCreate.StartDate, reservationCreate.EndDate))
            {
                return ValidationProblem("Invalid dates for reservation.");
            }

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

        private static bool ValidatePeriod(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                return false;
            }
            return true;
        }
    }
}
