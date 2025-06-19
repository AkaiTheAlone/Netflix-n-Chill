using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Netflix_n_Chill.Business;
using Netflix_n_Chill.Data.ValueObject;

namespace Netflix_n_Chill.Controllers
{

    [ApiVersion("1")]
    //[Route("api/[controller]")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private IPersonBusiness _person { get; set; }
        //private readonly ILogger _logger;
        public PersonController(IPersonBusiness personB, ILogger<PersonController> logger)
        {
            _person = personB;
            //_logger = logger;
        }
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetAll()
        {
            return Ok(_person.FindAll());
        }
        [HttpGet("{ID}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(int id)
        {
            var person = _person.FindByID(id);
            if (person == null) return NotFound("Person ID Not found!");
            return Ok(person);
        }
        //from body is a directive used to get all the json body sent to the adress
        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult PostCreate([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest("Empty Body!");

            return Ok(_person.Create(person));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult PutUpdate([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest("Empty Body!");

            return Ok(_person.Update(person));
        }

        [HttpDelete("{ID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long ID)
        {
            if (_person.FindByID(ID) == null) return NotFound();

            _person.Delete(ID);

            return NoContent();
        }
    }
}

