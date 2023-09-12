using AutoMapper;
using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using MagicVilla_API.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Logging;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly IMapper _mapper;
        private readonly MagicVillaDBContext _magicVillaDBContext;
        public VillaController(ILogger<VillaController> logger, MagicVillaDBContext magicVillaDBContext, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;   
            _magicVillaDBContext = magicVillaDBContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VillaViewModel>>> GetVillas()
        {
            IEnumerable<Villa>allVillas = await _magicVillaDBContext.Villas.ToListAsync();

            //Projecting from a list of Villa object to a list ofVilla VillaViewModel object without AutoMapper
            //var allVillasViewModel = allVillas.Select(v => new VillaViewModel
            //{
            //    IdVilla = v.IdVilla,
            //    Name = v.Name,
            //    Details = v.Details,
            //    Price = v.Price,
            //    ImageUrl = v.ImageUrl,
            //    Amenity = v.Amenity
            //});

            return Ok(_mapper.Map<IEnumerable<VillaViewModel>>(allVillas));
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        public async Task<ActionResult<VillaViewModel>> GetVilla(int id) 
        {
            if (id == 0)
            {
                _logger.LogError($"The Villa with id=> {id} do not exist ");
                return BadRequest();
            }

            var oneVilla = await _magicVillaDBContext.Villas.FirstOrDefaultAsync(v => v.IdVilla == id);

            if (oneVilla == null)
            {
                return NotFound();

            }
           //Projecting from a Villa object to VillaViewModel object without AutoMapper
            //var oneVillasViewModel = new VillaViewModel
            //{
            //    IdVilla = oneVilla.IdVilla,
            //    Name = oneVilla.Name,
            //    Details = oneVilla.Details,
            //    Price = oneVilla.Price,
            //    ImageUrl = oneVilla.ImageUrl,
            //    Amenity = oneVilla.Amenity
            //};
            return Ok(_mapper.Map<VillaViewModel>(oneVilla));    
          
        }
        [HttpPost]
        public async Task<ActionResult<VillaDto>> CreateVilla( [FromBody] VillaDto villa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var nameNewVillaExist = await _magicVillaDBContext.Villas.FirstOrDefaultAsync(v => v.Name.ToLower() == villa.Name.ToLower()) != null;
           

            if (nameNewVillaExist)
            {
                ModelState.AddModelError("ExistentName", "The name of villa that you are tray enter already exist");
                return BadRequest(ModelState);
            }

            //Projecting from a VillaDto object to Villa object without AutoMapper
            //Villa newVilla = new () 
            //{
            //    Name = villa.Name, 
            //    Details = villa.Details,
            //    Price = villa.Price,
            //    Capacity = villa.Capacity,
            //    Dimensions = villa.Dimensions,
            //    ImageUrl = villa.ImageUrl,  
            //    Amenity = villa.Amenity,
            //    CreationDate = DateTime.Now,
            //    UpdateTime = DateTime.Now
                
            //};
           Villa newVilla = _mapper.Map<Villa>(villa);
           await _magicVillaDBContext.Villas.AddAsync(newVilla);
           await _magicVillaDBContext.SaveChangesAsync();
            
            return CreatedAtRoute("GetVilla", new { id = newVilla.IdVilla }, newVilla);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVilla(int id) 
        {
            var villaToDelete = await _magicVillaDBContext.Villas.FirstOrDefaultAsync(v => v.IdVilla == id);
            if (villaToDelete == null)
            {
                return NotFound();
            }
           _magicVillaDBContext.Villas.Remove(villaToDelete);  
           await _magicVillaDBContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaDto villaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            
            var villaToUpdate = await _magicVillaDBContext.Villas.FirstOrDefaultAsync(v => v.IdVilla == id);
            if (villaToUpdate == null)
            { return NotFound(); }

             // Use AutoMapper to map properties from villaDto to villaToUpdate
            _mapper.Map(villaDto, villaToUpdate);

            // Update the remaining properties if needed
            villaToUpdate.CreationDate = DateTime.Now;
            villaToUpdate.UpdateTime = DateTime.Now;

            _magicVillaDBContext.Villas.Update(villaToUpdate);
            await _magicVillaDBContext.SaveChangesAsync();

            return CreatedAtRoute("GetVilla", new { id = villaToUpdate.IdVilla }, villaToUpdate);


        }



    }
}
