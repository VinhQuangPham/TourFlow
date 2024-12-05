
using TourFlowBE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[ApiController]
[Route("api/[controller]")]
public class UserDataCollectionController: ControllerBase
{
   
    private readonly TourFlowContext _tourFlowContext;
    public UserDataCollectionController(TourFlowContext tourFlowContext)
    {
        _tourFlowContext = tourFlowContext;
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]UserDataCollection userInfor)
    {
        await _tourFlowContext.UserDataCollections.AddAsync(userInfor);
        int result = await _tourFlowContext.SaveChangesAsync();
        if (result == 0)
        {
            return BadRequest("something wrong about POST action in UserDataCollectionController");
        } else {
            return Ok("Saved successfully");
        }
    }
    
    [HttpGet("{userId}")]
    public async Task<IActionResult> Get(int userId)
    {
        var result =  await _tourFlowContext.UserDataCollections.Where(u=>u.UserId == userId).ToListAsync();      
        return Ok(result);       
    }
}
 