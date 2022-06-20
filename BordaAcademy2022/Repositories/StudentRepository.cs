using BordaAcademy2022.Entities;

namespace BordaAcademy2022.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> _students;

        public StudentRepository()
        {
            _students = new List<Student>
            {
                new Student() { Id = 0, Name = "Bilal"},
                new Student() { Id = 1, Name = "Begum"},
                new Student() { Id = 2, Name = "Berkan"},
                new Student() { Id = 3, Name = "Bora"},
            };
        }

        public void CreateStudent(Student student)
        {
            _students.Add(student);
        }

        public void DeleteStudent(int id)
        {
            _students.RemoveAll(x => x.Id == id);
        }

        public Student? GetStudentById(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }

        public List<Student> GetStudents()
        {
            return _students;
        }

        public void UpdateStudent(Student student)
        {
            _students.RemoveAll(x => x.Id == student.Id);
            _students.Add(student);
        }
    }
}
