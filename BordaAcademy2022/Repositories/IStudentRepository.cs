using BordaAcademy2022.Entities;

namespace BordaAcademy2022.Repositories
{
    public interface IStudentRepository
    {
        void CreateStudent(Student student);
        Student? GetStudentById(int id);
        List<Student> GetStudents();
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
