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
        ///    Gets an individual cookie by its id provided by the id 
        ///    url query parameter
        /// </summary>
        /// <param name="id">The specific cookie's id</param>
        /// <returns>A Json result containing the individual cookie data</returns>
        [HttpGet("get")]
        public IActionResult GetCookie(int id)
        {
            Cookie cookie = _repo.GetById(id);

            if (cookie == null) return NotFound();
            return Json(cookie);
        }

        /// <summary>
        ///     Gets an amount of cookies specified by the amount 
        ///     url query parameter
        /// </summary>
        /// <param name="amount">Amount of cookies</param>
        /// <returns>Json that contains an array of the cookies</returns>
        [HttpGet("getbatch")]
        public IActionResult GetCookies(int amount)
        {
            var cookies = _repo.GetByAmount(amount);
            
            return Json(cookies);
        }

        /// <summary>
        ///     Creates a cookie with the provided data by the requests body
        /// </summary>
        /// <param name="cookie">The cookie data from the request body</param>
        /// <returns>A http status code</returns>
        [HttpPost("create")]
        public IActionResult MakeCookie([FromBody] Cookie cookie)
        {
            var cookieValidator = new CookieValidator();

            if (cookieValidator.Validate(cookie))
            {
                _repo.Insert(cookie);
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        ///     Updates a cookie with the provided data in the request body
        /// </summary>
        /// <param name="cookie">The specific cookie's new details</param>
        /// <returns>A http status result</returns>
        [HttpPatch("update")]
        public IActionResult UpdateCookie([FromBody] Cookie cookie)
        {
            var cookieValidator = new CookieValidator(options => options.IdNotZero = true);

            if (cookieValidator.Validate(cookie))
            {
                _repo.Update(cookie);
                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        ///     Deletes the specific cookie specified by it's id
        /// </summary>
        /// <param name="id">The id of the cookie to be deleted</param>
        /// <returns>A http status result</returns>
        [HttpDelete("delete")]
        public IActionResult DeleteCookie(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}