using Student_Service.Models;

namespace Student_Service
{
    public interface IStudentRepo
    {
        // CRUD operations
        List<Student> GetStudents();
        Student  AddStudent(Student student);
        Student StudentGetStudentById(int id);
        int UpdateStudent(int id, Student student);
        int DeleteStudent(int id);
    }
}
