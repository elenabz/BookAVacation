using AutoMapper;
using BookaVacation.DTO;
using BookAVacation.Data;
using BookAVacation.DTO;
using BookAVacation.Interfaces;
using BookAVacation.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookAVacation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        public PropertyController(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Property>))]
        public IActionResult GetProperties() {
            var properties = _propertyRepository.GetProperties();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(properties);
        }

        [HttpGet("{propertyId}")]
        [ProducesResponseType(200, Type = typeof(Property))]
        [ProducesResponseType(400)]
        public IActionResult GetProperty(int propertyId)
        {
            if (!_propertyRepository.PropertyExists(propertyId))
            {
                return NotFound();
            }

            var property = _propertyRepository.GetProperty(propertyId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(property);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public IActionResult CreateProperty([FromBody] PropertyDto propertyCreate)
        {
            if(propertyCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var propertyMap = _mapper.Map<Property>(propertyCreate);
            if (!_propertyRepository.CreateProperty(propertyMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving the property.");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created.");
        }

        [HttpPut("{propertyId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateProperty(int propertyId, [FromBody] Property updatedProperty)
        {
            if(updatedProperty == null)
            {
                return BadRequest(ModelState);
            }

            if (propertyId != updatedProperty.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_propertyRepository.PropertyExists(propertyId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_propertyRepository.UpdateProperty(updatedProperty))
            {
                ModelState.AddModelError("", "Something went wrong while updating the property.");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        [HttpDelete("{propertyId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public IActionResult DeleteProperty(int id)
        {
            if (!_propertyRepository.PropertyExists(id))
            {
                return NotFound();
            }
            var propertyToDelete = _propertyRepository.GetProperty(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_propertyRepository.DeleteProperty(propertyToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting property.");
            }
            return NoContent();
        }

    }
}