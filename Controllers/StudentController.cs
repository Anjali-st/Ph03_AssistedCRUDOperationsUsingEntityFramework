using Sec_09CrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sec_09CrudOperation.Controllers
{
    public class StudentController : Controller
    {
        public IHttpActionResult GetAllStudents()

        {

            IList<StudentViewModel> students = null;



            using (var ctx = new School1Entities())

            {

                students = ctx.Students

                            .Select(s => new StudentViewModel()

                            {

                                Id = s.Id,

                                Name = s.Name,

                                Email = s.Email,

                                Class = s.Class,

                                Address = s.Address

                            }).ToList<StudentViewModel>();

            }



            if (students.Count == 0)

            {

                return NotFound();

            }



            return Ok(students);

        }

        private IHttpActionResult Ok(IList<StudentViewModel> students)
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult PostNewStudent(StudentViewModel student)

        {

            if (!ModelState.IsValid)

                return BadRequest("Invalid data.");



            using (var ctx = new School1Entities())

            {

                ctx.Students.Add(new Student()

                {

                    Name = student.Name,

                    Email = student.Email,

                    Address = student.Address,

                    Class = student.Class

                });



                ctx.SaveChanges();

            }



            return Ok();

        }

        private IHttpActionResult Ok()
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult Put(StudentViewModel student)

        {

            if (!ModelState.IsValid)

                return BadRequest("Not a valid model");



            using (var ctx = new School1Entities())

            {

                var existingStudent = ctx.Students.Where(s => s.Id == student.Id)

                                                        .FirstOrDefault<Student>();



                if (existingStudent != null)

                {

                    existingStudent.Name = student.Name;

                    existingStudent.Address = student.Address;

                    existingStudent.Email = student.Email;

                    existingStudent.Class = student.Class;



                    ctx.SaveChanges();

                }

                else

                {

                    return NotFound();

                }

            }



            return Ok();

        }



        [HttpDelete]

        public IHttpActionResult Delete(int id)

        {

            if (id <= 0)

                return BadRequest("Not a valid student id");



            using (var ctx = new School1Entities())

            {

                var student = ctx.Students

                    .Where(s => s.Id == id)

                    .FirstOrDefault();



                ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;

                ctx.SaveChanges();

            }



            return Ok();

        }

    }

}

