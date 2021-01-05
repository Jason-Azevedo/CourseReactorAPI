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
        public IActionResult GetCookie(int id)
        {
            Cookie cookie = _repo.GetById(id);

            if (cookie == null) return NotFound();
            return Json(cookie);
        }

        [HttpGet("getbatch")]
        public IActionResult GetCookies(int amount)
        {
            var cookies = _repo.GetByAmount(amount);
            
            return Json(cookies);
        }

        [HttpPost("create")]
        public IActionResult MakeCookie([FromBody] Cookie cookie)
        {
            if (cookie.Name != string.Empty 
                && cookie.Description != string.Empty 
                && cookie.Recipe != string.Empty)
            {
                _repo.Insert(cookie);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPatch("update")]
        public IActionResult UpdateCookie([FromBody] Cookie cookie)
        {
            if (cookie.Id != 0 
                && cookie.Name != string.Empty 
                && cookie.Description != string.Empty 
                && cookie.Recipe != string.Empty)
            {
                _repo.Update(cookie);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteCookie(int id)
        {
            _repo.Delete(id);
            return Ok();
        }
    }
}