using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netflix_n_Chill.Models.Services;

namespace Netflix_n_Chill.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService { get; set; }
        private readonly ILogger _logger;
        public PersonController(IPersonService personService, ILogger logger)
        {
            _personService = personService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetPersons()
        {
            return Ok(_personService.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var person = _personService.FindByID(id);
            if (person == null)
            {
                return NotFound("Person ID Not found!");
            }
            return Ok(_personService.FindByID(id));
        }
    }
}

