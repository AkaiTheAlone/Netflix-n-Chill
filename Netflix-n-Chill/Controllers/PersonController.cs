using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Netflix_n_Chill.Business;
using Netflix_n_Chill.Models;

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
        public IActionResult GetAll()
        {
            return Ok(_person.FindAll());
        }
        [HttpGet("{ID}")]
        public IActionResult Get(int id)
        {
            var person = _person.FindByID(id);
            if (person == null) return NotFound("Person ID Not found!");
            return Ok(person);
        }
        //from body is a directive used to get all the json body sent to the adress
        [HttpPost]
        public IActionResult PostCreate([FromBody] Person person)
        {
            if (person == null) return BadRequest("Empty Body!");

            return Ok(_person.Create(person));
        }

        [HttpPut]
        public IActionResult PutUpdate([FromBody] Person person)
        {
            if (person == null) return BadRequest("Empty Body!");

            return Ok(_person.Update(person));

        }

        [HttpDelete("{ID}")]
        public IActionResult Delete(long ID)
        {
            if (_person.FindByID(ID) == null) return NotFound();

            _person.Delete(ID);
            //var person = _personService.FindByID(ID);
            //if (person == null) return NotFound();

            //_personService.Delete(person.Id);
            return NoContent();
        }


    }
}

