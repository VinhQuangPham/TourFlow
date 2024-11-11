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

        [HttpGet("test")]
        public IActionResult Get()
        {
            return Ok("hi");
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

   

        [HttpGet("destination/{destinationid}")]
        public async Task<IActionResult> GetToursByDestinationId(int destinationid)
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


        //url : http://localhost:5175/api/tour/getallforai
        [HttpGet("getallforai")]
        public async Task<IActionResult> GetAllAI()
        { 
            var tours = await (from tour in _dbContext.Tours 
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
                }).ToListAsync();

                var formattedTours = tours.Select(t => new {
                    t.Id,
                    t.DepartureLocation,
                    t.City,
                    t.Country,
                    StartDate = t.StartDate?.ToString("dd-MM-yy"),  
                    EndDate = t.EndDate?.ToString("dd-MM-yy"),
                    t.Duration.Value.Days,
                    t.Price,
                    t.AvailableSlots,
                    t.FirstImageUrl
                }).ToList(); 
            return Ok(formattedTours);
        }

        [HttpGet("{tourid}")]
        public async Task<IActionResult> GetTour(int tourid)
        {
            var tour = await _dbContext.Tours
                .Include(t => t.TourPlans)
                .Where(t => t.Id == tourid).ToListAsync();
            if (tour != null)
            {
                return Ok(tour);
            } else {
                return NotFound();
            }

        }
    }
}