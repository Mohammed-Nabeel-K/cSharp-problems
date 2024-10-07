using System.Transactions;
using System.Xml.Linq;

namespace WeekOne
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Course { get; set; }

        public Student(int id,string name, int age, string course) { 
            Id = id;
            Name = name;   
            Age = age;
            Course = course;
        }

    }

    public class Courses
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public Courses(int courseid, string coursename)
        {
            CourseId = courseid;
            CourseName = coursename;
        }
    }

    class StudentManager
    {
        public List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public void RemoveStudent(string name)
        {
            var DeletingList  = students.Where(s => s.Name == name).First();
            students.Remove(DeletingList);
        }
        public void ViewStudents()
        {
            foreach (Student student in students)
            {
                Console.WriteLine($"Name = {student.Name}, id = {student.Id}, age = {student.Age} course = {student.Course} ");
            }
        }
    }

    class CourseManager
    {
        public List<Courses> courses = new List<Courses>();

        public void AddCourse(Courses course)
        {
            courses.Add(course);
        }
        public void ViewCourses()
        {
            foreach(Courses course in courses)
            {
                Console.WriteLine($"course id = {course.CourseId} course name = {course.CourseName}");
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();
            CourseManager courseManager = new CourseManager();

            studentManager.AddStudent(new Student(10, "nabeel", 23, "dotnet"));
            studentManager.AddStudent(new Student(14, "ainas", 19, "python"));
            studentManager.AddStudent(new Student(12, "mubashir", 20, "flutter"));
            studentManager.AddStudent(new Student(15, "adarsh", 22, "mean"));
            studentManager.AddStudent(new Student(20, "ajfar", 21, "dotnet"));

            Console.WriteLine("list after added");
            studentManager.ViewStudents();

            studentManager.RemoveStudent("ajfar");
            studentManager.RemoveStudent("mubashir");

            Console.WriteLine("list after removed");
            studentManager.ViewStudents();

            courseManager.AddCourse(new Courses(13, "dotnet"));
            courseManager.AddCourse(new Courses(14, "python"));

            Console.WriteLine("Added Courses");
            courseManager.ViewCourses();

            var Above20 = studentManager.students.Where(s => s.Age > 20);
            Console.WriteLine("students whose age is above 20");
            foreach (Student student in Above20)
            {
                Console.WriteLine(student.Name);
            }

            var dotnetStudents = studentManager.students.Where(s => s.Course == "dotnet");
            Console.WriteLine("students with dotnet");
            foreach (Student student in dotnetStudents)
            {
                Console.WriteLine(student.Name);
            }



            //int studid = 1;
            //Console.WriteLine("select a option that you need\n 1.students \n 2.courses");
            //int num = Console.Read();
            //switch (num)
            //{
            //    case 1:
            //        Console.WriteLine("enter your option\n 1.Add Student \n Remove Student \n View Student ");
            //        int opt1 = Console.Read();
            //        switch (opt1)
            //        {
            //            case 1:
            //                Console.WriteLine("enter student name");
            //                string name = Console.ReadLine();
            //                Console.WriteLine("enter student age");
            //                int age = Console.Read();
            //                Console.WriteLine("enter student course");
            //                string course = Console.ReadLine();
            //                studentManager.AddStudent(new Student( studid,name, age,course));
            //                studid++;
            //                break;
            //            case 2:
            //                studentManager.RemoveStudent()
            //                break ;
            //            case 3:

            //        }
            //        break;

            //    case 2:
            //        Console.WriteLine("enter your option\n 1.Add Student \n Remove Student \n View Student ");
            //        break;
            //    default:
            //        Console.WriteLine("enter valid option");
            //        break;
            //}

        }
    }
}