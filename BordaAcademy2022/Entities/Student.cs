using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BordaAcademy2022.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public int StudentNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
