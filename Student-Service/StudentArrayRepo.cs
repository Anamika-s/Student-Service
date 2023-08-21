using Student_Service.Models;

namespace Student_Service
{
    public class StudentArrayRepo : IStudentRepo
    {
        Student[] students = null;
        public StudentArrayRepo()
        {
            if(students==null)
            {
                students = new Student[10];
                students[0] = new Student() { Id = 1, Name = "Aashna", BatchCode = "DotNet", Marks = 90, Dob = Convert.ToDateTime("12/12/2000") };

                students[1] = new Student() { Id = 2, Name = "Priynaka", BatchCode = "DotNet", Marks = 87, Dob = DateTime.Parse("01/01/2001") };
                students[2] = new Student() { Id = 3, Name = "Tisha", BatchCode = "SAP", Marks = 98, Dob = DateTime.Parse("01/01/2002") };
                students[3] = new Student() { Id = 4, Name = "Naveen", BatchCode = "SAP", Marks = 90, Dob = DateTime.Parse("02/05/2001") };
                    

            }
        }
        public Student AddStudent(Student student)
        {
            students[students.Length+1] = student;
            return student;
        }

        public int DeleteStudent(int id)
        {
            return 1;
        }

        public List<Student> GetStudents()
        {
            return students.ToList();
        }

        public Student StudentGetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateStudent(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
