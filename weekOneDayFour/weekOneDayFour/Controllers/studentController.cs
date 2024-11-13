using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using weekOneDayFour.Models;
using weekOneDayFour.services;

namespace weekOneDayFour.Controllers
{
    


    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]

    public class studentController : ControllerBase
    {

        public readonly IStudentServices _istudentservices;

        public studentController(IStudentServices studentservices)
        {
            _istudentservices = studentservices;
        }


        [HttpGet(Name = "getallelements")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult getAllData()
        {
            //var studentsList = _istudentservices.getAllStudents();
            //if (studentsList == null)
            //    return NotFound();

            return Ok();
        }
        [HttpGet]
        [Route("{id}", Name = "getsingleelements")]
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
        //[Route("create", Name = "createstudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult createStudents([FromBody] studentModel model)
        {
            _istudentservices.createStudent(model);
            return Ok();
        }
        [HttpPut]
        [Route("update", Name = "updatestudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult updateStudents([FromBody] studentModel model)
        {


            _istudentservices.updateStudent(model);
            return Ok();
        }

        [HttpDelete]
        [Route("delete", Name = "deletestudentsbyname")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult deleteStudent(int id)
        {
            _istudentservices.deleteStudentById(id);
            return Ok();
        }

    }

}

