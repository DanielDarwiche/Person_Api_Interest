using Microsoft.AspNetCore.Mvc;
using Person_Api_Interest.Models;
using Person_Api_Interest.Services;

namespace Person_Api_Interest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private Icrud<Person> crud;
        //implementing controllers of person, with repository pattern Icrud

        public PersonController(Icrud<Person> cd)
        {
            this.crud = cd;
        }

        [HttpGet("GetPerson")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            try
            {
                var res = await crud.GetSingel(id);
                if (res == null)
                {
                    return NotFound("Could not find anyone by this id");
                }
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data");
            }
        }

        //Uppgift  -  Hämta alla personer           
        [HttpGet("DisplayAllPeople")]
        public async Task<IActionResult> GetAllPeople()
        {
            try
            {
                return Ok(await crud.GetAll());
            }
            catch (Exception)
            {
                return NotFound("Could not find data..");
            }
        }

        [HttpDelete("DeletePerson")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            try
            {
                var persD = await crud.GetSingel(id);
                if (persD == null)
                {
                    return NotFound($"A person with id: {id} was not found");
                }
                return await crud.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error...");
            }
        }


        [HttpPut("Update")]
        public async Task<ActionResult<Person>> UpdatePerson(int id, Person per)
        {
            try
            {
                if (id != per.PersonId)
                {
                    return BadRequest("The set id and the updated id are not matching");
                }
                var PersonToUpdate = await crud.GetSingel(id);

                if (PersonToUpdate == null)
                {
                    return NotFound($"Person With ID {id} was not found");
                }
                return await crud.Update(per);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }

        [HttpPost("RegisterPerson")]
        public async Task<ActionResult<Person>> CreateNewPerson(Person per)
        {
            try
            {
                if (per == null)
                {
                    return BadRequest();
                }
                var regPers = await crud.Add(per);
                return CreatedAtAction(nameof(GetPerson),
                    new { id = regPers.PersonId }, regPers);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error");
            }
        }
    }
}
