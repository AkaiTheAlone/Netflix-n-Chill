using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix_n_Chill.Business;
using Netflix_n_Chill.Business.Implementations;
using Netflix_n_Chill.Models;

namespace Netflix_n_Chill.Controllers
{
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookBusiness _business;
        public BookController(IBookBusiness business)
        {
            _business = business;
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            return Ok(_business.FindByID(id));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_business.FindAll());
        }
        [HttpPost]
        public IActionResult PostCreate([FromBody] Books book)
        {
            if (book == null) return BadRequest("Invalid book!");

            return Ok(_business.Create(book));
        }
        [HttpPut]
        public IActionResult PutUpdate([FromBody] Books book)
        {
            if (book == null) return BadRequest("Invalid book!");
            return Ok(_business.Update(book));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _business.Delete(id);
            return NoContent();
        }

    }
}
