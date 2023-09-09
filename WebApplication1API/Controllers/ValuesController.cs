using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult getValues()
        {
            string []valPlaces = new string[] { "Baliuag", "Bulacan", "Hagonoy" };
            return Ok(valPlaces);

        }
    }
}
