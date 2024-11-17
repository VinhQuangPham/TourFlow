
using Microsoft.AspNetCore.Mvc;
using TourFlowBE.Models;

namespace TourFlow_gitBE.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    { 
        private readonly TourFlowContext _dbContext;
        private readonly GoogleTokenService _googleTokenService;
        public AuthController(TourFlowContext dbContext, GoogleTokenService googleTokenService)
        {
            _dbContext = dbContext;
            _googleTokenService = googleTokenService;
        }

        [HttpPost("google-signin")]
        public async Task<IActionResult> GoogleSignIn([FromBody] GoogleSignInRequest request)
        { 
            Console.WriteLine("hiii");
            try 
            { 
                var payload = await _googleTokenService.ValidateGoogleToken(request.IdToken);
                string email = payload.Email;
                Console.WriteLine(email);
                
                return Ok(); 
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
    public class GoogleSignInRequest
    {
        public string IdToken { get; set; }
    }
}