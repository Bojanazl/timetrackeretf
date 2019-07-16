using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TimeTracker;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace TimeTrackerEtf.Controllers
{
    public class DummyAuthController : Controller
    {
        private IConfiguration _configuration;
        public DummyAuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("/get-token")]
        public IActionResult GenerateToken(
            string name = "etf-workshp", bool admin = false)
        {
            var jwt = JwtTokenGenerator.Generate(
                name, admin, _configuration["Tokens:Issuer"],
                _configuration["Tokens:Key"]);

            return Ok(jwt);
        }
    }

}
