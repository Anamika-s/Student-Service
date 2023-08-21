namespace Student_Service.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BatchCode { get; set; }
        public int Marks { get; set; }

        public DateTime Dob { get; set; }

    }
}
