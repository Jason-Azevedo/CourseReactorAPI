using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CourseReactorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CookiesController : Controller
    {
        /// <summary>
        ///    Gets an individual cookie by its id
        /// </summary>
        /// <param name="id">The specific cookie's id</param>
        /// <returns>A Json result containing the individual cookie data</returns>
        [HttpGet("get")]
        public async Task<JsonResult> GetCookie(int id)
        {
            return Json("Here is your cookie with the id: " + id);
        }

        // Get a specific amount of cookies, default 10

        // Create a new cookie

        // Update an existing cookie

        // Delete a cookie
    }
}