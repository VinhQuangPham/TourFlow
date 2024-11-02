using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourFlowBE.Models;

namespace TourFlowBE.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationController: ControllerBase
    {
        private readonly TourFlowContext _dbContext;
        public DestinationController(TourFlowContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        //Get countries
        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _dbContext.CountryDestinations.ToListAsync();
            return Ok(countries);
        }

        //Get cities
        [HttpGet("cities")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _dbContext.CityDestinations
                            .Select(c => new {
                                c.Id,
                                c.City
                            })
                            .ToListAsync();
            return Ok(cities);
        }
 
 
    }
    
}