using cwiczenia_3_s16324.Models;
using cwiczenia_3_s16324.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_3_s16324.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        //GET student with indexNumber
        [HttpGet("{indexNumber}")]
        public IActionResult GetStudents(string orderBy, string indexNumber) 
        {
            
            Student StudentQueried  = new DataQueryManager().GetStudents("index", indexNumber);
            if (StudentQueried != null)
            {
                return Ok(StudentQueried);
            }
            else
            {
                return NotFound("Student with indexNumber " + indexNumber + " not found.");
            }
           
        }

        //GET list of all students
        [HttpGet]
        public IActionResult GetStudents()
        {
            var list = new DataQueryManager().GetStudents();
            return Ok(list);
        }

        //PUT update data of student
        [HttpPut("{indexNumber}")]
        public IActionResult UpdateStudents(Student student, string indexNumber)
        {
            //var list = new DataQueryManager().GetStudents();
            Student StudentUpdated = new DataUpdateManager().updateStudent(student, indexNumber);
            return Ok(StudentUpdated);

        }

        //PUT new student
        [HttpPut]
        public IActionResult CreateStudents(Student student)
        {
            IActionResult result = null;
            ValidationManager validate = new ValidationManager();
            if (student.validate()) {
                if (validate.validateIndexFormat(student.IndexNumber))
                {
                    var list = new DataInsertManager().AddStudents(student);
                    result = Created("GET: students/" + student.IndexNumber, list);
                    if (list == null)
                    {
                        result = ValidationProblem("Student with same indexNumber already exist.");
                    }
                }
                else
                {
                    result = ValidationProblem("Incorrect indexNumber format.");
                }
            }
            else
            {
                result = ValidationProblem("Missing data.");
            }
            return result;
        }

        //DELETE student
        [HttpDelete("{indexNumber}")]
        public IActionResult DeleteStudents(string indexNumber)
        {
            
            //List<Student> StudentUpdated = new DataDeleteManager().DeleteStudent(indexNumber);
            Boolean StudentDelted = new DataDeleteManager().DeleteStudent(indexNumber);
            if (StudentDelted)
            {
                return Ok("Student with indeXNumber " + indexNumber + " deleted.");
            }
            else
            {
                return NotFound("Student with indexNumber " + indexNumber + " not found.");
            }
            
        }


    }
}
