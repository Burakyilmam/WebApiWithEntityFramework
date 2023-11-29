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
            return Ok(context.Students.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(context.Students.FirstOrDefault(x => x.Id == id));
            //// return Ok(context.Students.Where(x=>x.Id == id).ToList());
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var value = context.Students.Find(id);
            context.Remove(value);
            context.SaveChanges();
            return Ok();
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
            return Ok();
        }
    }
}
