using Microsoft.AspNetCore.Mvc;
using Person_Api_Interest.Models;
using Person_Api_Interest.Services;

namespace Person_Api_Interest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private Icrud<Link> crud;
        public LinkController(Icrud<Link> cd)
        {
            this.crud = cd;
        }

        [HttpGet("GetLink")]
        public async Task<ActionResult<Link>> GetLink(int id)
        {
            try
            {
                var res = await crud.GetSingel(id);
                if (res == null)
                {
                    return NotFound("Could not find a Link by this id");
                }
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data");
            }
        }

        [HttpGet("DisplayAllLinks")]
        public async Task<IActionResult> GetAllLinks()
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

        [HttpDelete("DeleteLink")]
        public async Task<ActionResult<Link>> DeleteLink(int id)
        {
            try
            {
                var LinkToDelete = await crud.GetSingel(id);
                if (LinkToDelete == null)
                {
                    return NotFound($"An interest with id: {id} was not found");
                }
                return await crud.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error...!!!!");
            }
        }


        [HttpPut("Update")]
        public async Task<ActionResult<Link>> UpdateLink(int id, Link linkedink)
        {
            try
            {
                if (id != linkedink.LinkId)
                {
                    return BadRequest("The set id and the updated id are not matching");
                }
                var PersonToUpdate = await crud.GetSingel(id);

                if (PersonToUpdate == null)
                {
                    return NotFound($"Interest With ID {id} was not found");
                }
                return await crud.Update(linkedink);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error..");
            }
        }

        [HttpPost("Register")]
        public async Task<ActionResult<Link>> CreateNewLink(Link linked)
        {
            try
            {
                if (linked == null)
                {
                    return BadRequest();
                }
                var regPers = await crud.Add(linked);
                return CreatedAtAction(nameof(GetLink),
                    new { id = regPers.LinkId }, regPers);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error..");
            }
        }
    }
}
