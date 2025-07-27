using Microsoft.AspNetCore.Mvc;
using Netflix_n_Chill.Business.Abstractions;
using Netflix_n_Chill.Data.ValueObject;

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
        [ProducesResponseType((200), Type = typeof(BookVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetByID(int id)
        {
            return Ok(_business.FindByID(id));
        }
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetAll()
        {
            return Ok(_business.FindAll());
        }
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult PostCreate([FromBody] BookVO book)
        {
            if (book == null) return BadRequest("Invalid book!");

            return Ok(_business.Create(book));
        }
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult PutUpdate([FromBody] BookVO book)
        {
            if (book == null) return BadRequest("Invalid book!");
            return Ok(_business.Update(book));
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(204)] //-> No content
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int id)
        {
            _business.Delete(id);
            return NoContent();
        }

    }
}
