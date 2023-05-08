using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Person_Api_Interest.Models;
using Person_Api_Interest.Services;

namespace Person_Api_Interest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private Icrud<Interest> crud;
        public InterestController(Icrud<Interest> cd)
        {
            this.crud = cd;
        }

        [HttpGet("GetInterest")]
        public async Task<ActionResult<Interest>> GetInterest(int id)
        {
            try
            {
                var res = await crud.GetSingel(id);
                if (res == null)
                {
                    return NotFound("Could not find an interest by this id");
                }
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data");
            }
        }

        [HttpGet("DisplayAllInterests")]
        public async Task<IActionResult> GetAllInterests()
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

        [HttpDelete("DeleteInterest")]
        public async Task<ActionResult<Interest>> DeleteInterest(int id)
        {
            try
            {
                var InterestToDelete = await crud.GetSingel(id);
                if (InterestToDelete == null)
                {
                    return NotFound($"An interest with id: {id} was not found");
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
        public async Task<ActionResult<Interest>> UpdateInterest(int id, Interest InteR)
        {
            try
            {
                if (id != InteR.InterestId)
                {
                    return BadRequest("The set id and the updated id are not matching");
                }
                var PersonToUpdate = await crud.GetSingel(id);

                if (PersonToUpdate == null)
                {
                    return NotFound($"Interest With ID {id} was not found");
                }
                return await crud.Update(InteR);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error..");
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult<Interest>> CreateNewInterest(Interest inteR)
        {
            try
            {
                if (inteR == null)
                {
                    return BadRequest();
                }
                var regPers = await crud.Add(inteR);
                return CreatedAtAction(nameof(GetInterest),
                    new { id = regPers.InterestId }, regPers);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error...");
            }
        }


    }
}
