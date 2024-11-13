using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using weekOneDayFour.Models;
using weekOneDayFour.Repository;

namespace weekOneDayFour.services
{
    public interface IStudentServices
    {
        public void getAllStudents();
        public studentModel getStudentById(int id);

        public void createStudent( studentModel student);
        public void updateStudent( studentModel student);
        public void deleteStudentById(int id);
    }
    public class studentServices : IStudentServices
    {
        private readonly string _connectionString;

        public studentServices(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void getAllStudents()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users VALUES ('arjun','arjun')";
                using (SqlCommand command = connection.CreateCommand()) {
                    int added = command.ExecuteNonQuery();
                    Console.WriteLine(added);
                }
                
                
            }

        }
        public studentModel getStudentById(int id)
        {
            var student = Lists.students.Where( n => n.Id == id).FirstOrDefault();
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
