using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourFlowBE.Models;

namespace TourFlowBE.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController: ControllerBase
    {
        private readonly TourFlowContext _dbContext;
        public CountryController( TourFlowContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var countries = await _dbContext.CountryDestinations
                            .Select(c => new {
                                c.Id,
                                c.Country
                            }).ToListAsync();
            return Ok(countries);
        }
    }
}