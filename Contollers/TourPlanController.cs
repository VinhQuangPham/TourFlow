// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using TourFlowBE.Models;

// namespace TourFlowBE.Controller
// {
//     [ApiController]
//     [Route("api/[controller]")]

//     public class TourPlanController: ControllerBase
//     {
//         private readonly TourFlowContext _dbContext;
//         public TourPlanController(TourFlowContext dbContext)
//         {
//             _dbContext = dbContext;
//         }

//         // GET http://localhost:5175/api/tourplan/<tourId>
//         [HttpGet("{TourId}")]
//         public async Task<IActionResult> Get(int TourId)
//         {
//             var query = from tourplan in _dbContext.TourPlans
//                         where tourplan.TourId == TourId
//                         select new {
//                             detailPlan = tourplan.Detail
//                         };
//             return Ok(await query.ToListAsync());
//         }
//     }
// }