using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourFlowBE.Models;

namespace TourFlowBE.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourController: ControllerBase
    {
        private readonly TourFlowContext _dbContext;
        public TourController(TourFlowContext dbContext)
        {
            _dbContext = dbContext;
        }

        // http://localhost:5175/api/tour/
        [HttpGet]
        public async Task<ActionResult> GetAllTours()
        {
            var tours = from tour in _dbContext.Tours 
                        join cityDestination in _dbContext.CityDestinations 
                        on tour.CityDestinationId equals cityDestination.Id
                        join countryDestination in _dbContext.CountryDestinations
                        on cityDestination.CountryDestinationId equals countryDestination.Id 
                        select new {
                            tour.Id,
                            tour.DepartureLocation,
                            cityDestination.City,
                            countryDestination.Country,
                            tour.StartDate,
                            tour.EndDate,
                            Duration = tour.EndDate - tour.StartDate,
                            tour.Price,
                            tour.AvailableSlots, 
                            FirstImageUrl = _dbContext.Imgs
                                .Where(img => img.CityDestinationId == cityDestination.Id)
                                .Select(img => img.Url)
                                .FirstOrDefault() 
                        };
            return Ok(tours);
        }

        [HttpGet("{destinationid}")]
        public async Task<IActionResult> GetTours(int destinationid)
        {
            var tours = await (from tour in _dbContext.Tours 
                join cityDestination in _dbContext.CityDestinations 
                on tour.CityDestinationId equals cityDestination.Id
                join countryDestination in _dbContext.CountryDestinations
                on cityDestination.CountryDestinationId equals countryDestination.Id 
                where cityDestination.Id == destinationid
                select new {
                    tour.Id,
                    tour.DepartureLocation,
                    cityDestination.City,
                    countryDestination.Country,
                    tour.StartDate,
                    tour.EndDate,
                    Duration = tour.EndDate - tour.StartDate,
                    tour.Price,
                    tour.AvailableSlots, 
                    FirstImageUrl = _dbContext.Imgs
                        .Where(img => img.CityDestinationId == cityDestination.Id)
                        .Select(img => img.Url)
                        .FirstOrDefault() 
                }).ToListAsync();
            return Ok(tours);
        }
    }
}