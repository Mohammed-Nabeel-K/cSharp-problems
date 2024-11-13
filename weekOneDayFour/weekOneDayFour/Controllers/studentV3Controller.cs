using Microsoft.AspNetCore.Mvc;
using weekOneDayFour.Models;
using weekOneDayFour.services;

namespace weekOneDayFour.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("3.0")]

    public class studentV3Controller : ControllerBase
    {

        public readonly IStudentV3Services _istudentservices;

        public studentV3Controller(IStudentV3Services studentservices)
        {
            _istudentservices = studentservices;
        }


        [HttpGet(Name = "getallelementsv3")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult getAllData()
        {
            var studentsList = _istudentservices.getAllStudents();
            if (studentsList == null)
                return NotFound();

            return Ok(studentsList);
        }
        [HttpGet]
        [Route("{id}", Name = "getsingleelementsv3")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult getStudent(int id)
        {

            var studentlist = _istudentservices.getStudentById(id);
            if (studentlist == null)
                return NotFound();
            return Ok(studentlist);
        }
        [HttpPost]
        [Route("create", Name = "createstudentsv3")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult createStudents([FromBody] studentModel model)
        {
            _istudentservices.createStudent(model);
            return Ok();
        }
        [HttpPut]
        [Route("update", Name = "updatestudentsv3")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult updateStudents([FromBody] studentModel model)
        {


            _istudentservices.updateStudent(model);
            return Ok();
        }

        [HttpDelete]
        [Route("delete", Name = "deletestudentsbynamev3")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult deleteStudent(int id)
        {
            _istudentservices.deleteStudentById(id);
            return Ok();
        }

    }
}
