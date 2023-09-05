using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Logging;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly MagicVillaDBContext _magicVillaDBContext;
        public VillaController(ILogger<VillaController> logger, MagicVillaDBContext magicVillaDBContext)
        {
            _logger = logger;
            _magicVillaDBContext = magicVillaDBContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {

            var allVillas = _magicVillaDBContext.Villas.ToList();

            return Ok(allVillas);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        public ActionResult<Villa> GetVilla(int id) 
        {
            if (id == 0)
            {
                _logger.LogError($"The Villa with id=> {id} do not exist ");
                return BadRequest();
            }

            var oneVilla = _magicVillaDBContext.Villas.FirstOrDefault(v => v.IdVilla == id);

            if (oneVilla == null)
            {
                return NotFound();

            }
            return Ok(oneVilla);    
          
        }
        [HttpPost]
        public ActionResult<VillaDto> CreateVilla(VillaDto villa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_magicVillaDBContext.Villas.FirstOrDefault(v => v.Name.ToLower() == villa.Name.ToLower()) != null)
            {
                ModelState.AddModelError("ExistentName", "The name of villa that you are tray enter already exist");
                return BadRequest(ModelState);
            }

            Villa newVilla = new Villa() 
            {
                Name = villa.Name, 
                Details = villa.Details,
                Price = villa.Price,
                Capacity = villa.Capacity,
                Dimensions = villa.Dimensions,
                ImageUrl = villa.ImageUrl,  
                Amenity = villa.Amenity,
                CreationDate = DateTime.Now,
                UpdateTime = DateTime.Now
                
            };
            _magicVillaDBContext.Villas.Add(newVilla);
            _magicVillaDBContext.SaveChanges();
            
            return CreatedAtRoute("GetVilla", new { id = newVilla.IdVilla }, newVilla);
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteVilla(int id) 
        {
            var villaToDelete = _magicVillaDBContext.Villas.FirstOrDefault(v => v.IdVilla == id);
            if (villaToDelete == null)
            {
                return NotFound();
            }
            _magicVillaDBContext.Villas.Remove(villaToDelete);  
            _magicVillaDBContext.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateVilla(int id, VillaDto villaDto)
        {
            if (villaDto == null)
            {
                return BadRequest();
            }

            var villaToUpdate = _magicVillaDBContext.Villas.FirstOrDefault(v => v.IdVilla == id);
            if (villaToUpdate == null)
            { return NotFound(); }

            villaToUpdate.Name = villaDto.Name;
            villaToUpdate.Details = villaDto.Details;
            villaToUpdate.Price = villaDto.Price;
            villaToUpdate.Capacity = villaDto.Capacity;
            villaToUpdate.Dimensions = villaDto.Dimensions;
            villaToUpdate.ImageUrl = villaDto.ImageUrl;
            villaToUpdate.Amenity = villaDto.Amenity;
            villaToUpdate.CreationDate = DateTime.Now;
            villaToUpdate.UpdateTime = DateTime.Now;

            _magicVillaDBContext.Villas.Update(villaToUpdate);
            _magicVillaDBContext.SaveChanges();

            return CreatedAtRoute("GetVilla", new { id = villaToUpdate.IdVilla }, villaToUpdate);


        }



    }
}
