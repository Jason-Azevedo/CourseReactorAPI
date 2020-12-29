using System.Threading.Tasks;
using CourseReactorAPI.Models;
using CourseReactorAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CourseReactorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CookiesController : Controller
    {

        private ICookieRepository _repo;
        private ILogger<CookiesController> _logger;

        public CookiesController(ILogger<CookiesController> logger, ICookieRepository repo)
        {
            _repo = repo;
            _logger = logger;
        }

        /// <summary>
        ///    Gets an individual cookie by its id
        /// </summary>
        /// <param name="id">The specific cookie's id</param>
        /// <returns>A Json result containing the individual cookie data</returns>
        [HttpGet("get")]
        public async Task<JsonResult> GetCookie(int id)
        {
            return Json(_repo.GetById(id));
        }

        // Get a specific amount of cookies, default 10

        // Create a new cookie

        // Update an existing cookie

        // Delete a cookie
    }
}