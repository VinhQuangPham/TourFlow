// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using TourFlowBE.Models;

// namespace TourFlowBE.Controller
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class ImgController: ControllerBase
//     {
//         private readonly TourFlowContext _dbContext;
//         public ImgController(TourFlowContext dbContext)
//         {
//             _dbContext = dbContext;
//         }

//         [HttpGet("{TourId}")]
//         public async Task<IActionResult> Get(int TourId)
//         {
//             var query =  from imgs in _dbContext.Imgs where imgs.TourId == TourId
//                             select new {
//                                 url=imgs.Url
//                             };
//             return Ok(await query.ToListAsync());
//         }
//     }
// }