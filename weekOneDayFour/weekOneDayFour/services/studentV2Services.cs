
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using weekOneDayFour.Models;
using weekOneDayFour.Repository;

namespace weekOneDayFour.services
{
    public interface IStudentV2Services
    {
        public IEnumerable<studentModel> getAllStudents();
        public studentModel getStudentById(int id);

        public void createStudent(studentModel student);
        public void updateStudent(studentModel student);
        public void deleteStudentById(int id);
    }
    public class studentV2Services : IStudentV2Services
    {
        public IEnumerable<studentModel> getAllStudents()
        {
            var students = Lists.students.Select(n => n);
            return students;
        }
        public studentModel getStudentById(int id)
        {
            var student = Lists.students.Where(n => n.Id == id).FirstOrDefault();
            return student;
        }

        public void createStudent(studentModel student)
        {

            Lists.students.Add(student);
        }
        public void updateStudent(studentModel student)
        {
            var oldstudent = Lists.students.Where(n => n.Id == student.Id).FirstOrDefault();


            oldstudent.Name = student.Name;
            oldstudent.Course = student.Course;
            oldstudent.Place = student.Place;

        }
        public void deleteStudentById(int id)
        {
            Lists.students.Remove(getStudentById(id));
        }


    }
}
