using BordaAcademy2022.Database;
using BordaAcademy2022.Entities;

namespace BordaAcademy2022.Repositories
{
    public class RealStudentRepository : IStudentRepository
    {
        private readonly DemoContext _demoContext;

        public RealStudentRepository(DemoContext demoContext)
        {
            _demoContext = demoContext;
        }   

        public void CreateStudent(Student student)
        {
            _demoContext.Students.Add(student);

            _demoContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _demoContext.Students.FirstOrDefault(i => i.Id == id);
            _demoContext.Students.Remove(student);

            _demoContext.SaveChanges();
        }

        public Student? GetStudentById(int id)
        {
            return _demoContext.Students.FirstOrDefault(x => x.Id == id);
        }

        public List<Student> GetStudents()
        {
            return _demoContext.Students.ToList();
        }

        public void UpdateStudent(Student student)
        {
            _demoContext.Students.Update(student);

            _demoContext.SaveChanges();
        }
    }
}
