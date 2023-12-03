using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly Context context;
        public StudentController(Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var students = context.Students.ToList();

            if (students.Count == 0)
            {
                return NotFound("Öğrenci Bulunmamaktadır.");
            }
            return Ok(students);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = context.Students.FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return NotFound($"{id} ID değeri olan değer bulunamadı.");
            }
            return Ok(student);

            // return Ok(context.Students.FirstOrDefault(x => x.Id == id));
            // return Ok(context.Students.Where(x=>x.Id == id).ToList());
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            var existingStudent = context.Students.FirstOrDefault(s => s.Id == student.Id);

            if (existingStudent != null)
            {
                return Conflict($"ID değeri {student.Id} olan öğrenci zaten mevcut.");
            }

            context.Students.Add(student);
            context.SaveChanges();

            return Ok($"ID değeri {student.Id} olan öğrenci başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = context.Students.Find(id);
            context.Remove(value);
            context.SaveChanges();
            return Ok($"ID değeri {value.Id} olan öğrenci başarıyla silindi.");
        }
        [HttpPut]
        public IActionResult Update(int id)
        {
            var value = context.Students.Find(id);
            value.Name = "Ali";
            value.Age = "20";
            value.Statu = false;
            context.Update(value);
            context.SaveChanges();
            return Ok($"ID değeri {value.Id} olan öğrenci başarıyla güncellendi.");
        }
    }
}
