using Student_Service.Models;
using System.Xml.Linq;

namespace Student_Service
{
    public class StudentRepo : IStudentRepo
    {
        static List<Student> students = null;
        public StudentRepo()
        {

            if (students == null)
            {
                students = new List<Student>()
                {
                    new Student() { Id = 1, Name = "Aashna", BatchCode = "DotNet", Marks = 90, Dob = Convert.ToDateTime("12/12/2000")},

                    new Student() { Id = 2, Name = "Priynaka", BatchCode = "DotNet", Marks = 87 , Dob = DateTime.Parse("01/01/2001")},
                    new Student() { Id = 3, Name = "Tisha", BatchCode = "SAP", Marks = 98, Dob = DateTime.Parse("01/01/2002")},
                    new Student() { Id = 4, Name = "Naveen", BatchCode = "SAP", Marks = 90, Dob = DateTime.Parse("02/05/2001")},
                    new Student() { Id = 5, Name = "Siddhant", BatchCode = "DotNet", Marks = 90, Dob = DateTime.Parse("01/01/2001")},
                    new Student() { Id = 6, Name = "Vaibhav", BatchCode = "DotNet", Marks = 90, Dob = DateTime.Parse("01/01/2001")}
    };
            }

}
public Student AddStudent(Student student)
        {
           students.Add(student);
            return student;
        }

        public int DeleteStudent(int id)
        {
           students.RemoveAt(id);
            return 1;
        }

        public List<Student> GetStudents()
        {
            return students;
        }

        public Student StudentGetStudentById(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        public int UpdateStudent(int id, Student student)
        {
           Student obj = students.FirstOrDefault(x => x.Id == id);
if(obj!=null)
            {
                foreach(Student temp in students)
                {
                    if(temp.Id == id)
                    {
                         temp.BatchCode = student.BatchCode; temp.Name = student.Name;
                        temp.Marks = student.Marks;
                    }
                }
                return 1;
            }
else 
                return 0;
        }
    }
}
