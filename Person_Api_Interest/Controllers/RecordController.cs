using Microsoft.AspNetCore.Mvc;
using Person_Api_Interest.Models;
using Person_Api_Interest.Services;

namespace Person_Api_Interest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private IRecord<Record> iRecOrd;
        public RecordController(IRecord<Record> rr)
        {
            this.iRecOrd = rr;
        }

        [HttpGet("DisplayAllRecords")]
        public async Task<IActionResult> GetAllRecords()
        {
            try
            {
                return Ok(await iRecOrd.GetAll());
            }
            catch (Exception)
            {
                return NotFound("Could not find data..");
            }
        }


        [HttpDelete("DeleteRecord")]
        public async Task<ActionResult<Record>> DeleteRecord(int id)
        {
            try
            {
                var RecordToDelete = await iRecOrd.GetSingel(id);
                if (RecordToDelete == null)
                {
                    return NotFound($"A record with id: {id} was not found");
                }
                return await iRecOrd.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error...!");
            }
        }






        [HttpGet("GetSingleRecord")]
        public async Task<ActionResult<Record>> GetSingleRecord(int id)
        {
            try
            {
                var res = await iRecOrd.GetSingel(id);
                if (res == null)
                {
                    return NotFound("Could not find a record by this id");
                }
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data");
            }
        }



        [HttpPut("Update")]
        public async Task<ActionResult<Record>> UpdateRecord(int id, Record recc)
        {
            try
            {
                if (id != recc.RecordId)
                {
                    return BadRequest("The set id and the updated id are not matching");
                }

                //RecToUpdate is the found record in table
                var RecToUpdate = await iRecOrd.GetSingel(id);

                if (RecToUpdate == null)
                {
                    return NotFound($"A Record with this ID is not found");
                }
                if (recc.PersonId == null || recc.InterestId == null)
                {
                    return BadRequest("The interest/interest - id is input wrongfully");
                }

                return await iRecOrd.Update(recc);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error.. Put in right details! ");
            }
        }


        [HttpPost("RegisterRecord")]
        public async Task<ActionResult<Record>> CreateNewRecord(Record recc)
        {
            try
            {
                if (recc == null)
                {
                    return BadRequest("Bad request! Change details!");
                }
                var regRecord = await iRecOrd.Add(recc);
                return CreatedAtAction(nameof(GetSingleRecord), new { id = recc.RecordId }, recc);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, could not complete registration");
            }
        }

        [HttpGet("DisplayPersonsInterests")]
        public async Task<ActionResult<Record>> DisplayPersonInterests(int id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("Bad request! Change details!");
                }
                return Ok(await iRecOrd.GetAllInterests(id));
            }
            catch (Exception)
            {
                return NotFound("Could not find data..");
            }
        }
        [HttpGet("DisplayPersonsLinks")]
        public async Task<ActionResult<Record>> DisplayPersonLinks(int id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("Bad request! Change details!");
                }
                return Ok(await iRecOrd.GetAllLinks(id));
            }
            catch (Exception)
            {
                return NotFound("Could not find data..");
            }
        }


    }
}
