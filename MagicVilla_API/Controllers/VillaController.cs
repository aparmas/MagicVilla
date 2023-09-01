using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using Microsoft.AspNetCore.Http;
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
        public IEnumerable<VillaDto> GetVillas() 
        {
            var villas = new List<VillaDto> 
            { 
                
                //new VillaDto {Name = "Villa Bayamo", CreationDate = DateTime.Now},
                //new VillaDto {Name = "Villa Cautillo", CreationDate = DateTime.Now}
            };

            return villas;
        }


    }
}
