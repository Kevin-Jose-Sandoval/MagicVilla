using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;

        public VillaController(ILogger<VillaController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            _logger.LogInformation("Get all villas");
            return Ok(VillaStore.villaList);
        }

        [HttpGet("id:int", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error to get a villa with ID " + id);
                return BadRequest();
            }
            
            var villa = VillaStore.villaList.FirstOrDefault(villa => villa.Id == id);
            if (villa == null) return NotFound();

            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            if(VillaStore.villaList.FirstOrDefault(villa => villa.Name.ToLower() == villaDto.Name.ToLower()) != null)
            {
                ModelState.AddModelError("ExistsName", "The villa with that name already exists");
                return BadRequest(ModelState);
            }

            if (villaDto == null) return BadRequest();
            if (villaDto.Id > 0) return StatusCode(StatusCodes.Status500InternalServerError);

            villaDto.Id = VillaStore.villaList.OrderByDescending(villa => villa.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villaDto);

            return CreatedAtRoute("GetVilla", new { id = villaDto.Id }, villaDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if(id == 0) return BadRequest();
            
            var villa = VillaStore.villaList.FirstOrDefault(villa => villa.Id== id);
            if(villa == null) return NotFound();

            VillaStore.villaList.Remove(villa);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto)
        {
            if (villaDto == null || id != villaDto.Id) return BadRequest();

            var villa = VillaStore.villaList.FirstOrDefault(villa => villa.Id == id);
            if (villa == null) return NotFound();

            villa.Name = villaDto.Name;
            villa.Capacity = villaDto.Capacity;
            villa.SquareMeter = villaDto.SquareMeter;

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> patchDto)
        {
            if (patchDto == null || id == 0) return BadRequest();

            var villa = VillaStore.villaList.FirstOrDefault(villa => villa.Id == id);
            if (villa == null) return NotFound();

            patchDto.ApplyTo(villa, ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return NoContent();
        }
    }
}
