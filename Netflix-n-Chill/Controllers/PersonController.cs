using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix_n_Chill.Models.Modelos;
using Netflix_n_Chill.Models.Services;

namespace Netflix_n_Chill.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService { get; set; }
        private readonly ILogger _logger;
        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetPersons()
        {
            return Ok(_personService.FindAll());
        }
        [HttpGet("{ID}")]
        public IActionResult GetPerson(int id)
        {
            var person = _personService.FindByID(id);
            if (person == null) return NotFound("Person ID Not found!");
            return Ok(person);
        }
        //from body is a directive used to get all the json body sent to the adress
        [HttpPost]
        public IActionResult PostCreate([FromBody] Person person)
        {
            if (person == null) return BadRequest("Empty Body!");

            return Ok(_personService.Create(person));

        }

        [HttpPut]
        public IActionResult PutUpdate([FromBody] Person person)
        {
            if (person == null) return BadRequest("Empty Body!");

            return Ok(_personService.Update(person));

        }

        [HttpDelete("{ID}")]
        public IActionResult Delete(long ID)
        {
            if (_personService.FindByID(ID) == null) return NotFound();

            _personService.Delete(ID);
            //var person = _personService.FindByID(ID);
            //if (person == null) return NotFound();

            //_personService.Delete(person.Id);
            return NoContent();
        }


    }
}

