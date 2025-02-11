using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Context;
using WebApiProject.Entities;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;

        public CategoriesController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet] // Listeleme işlemleri için kullanılan bir attributedir.
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList(); //tolist ile verilerimizi getiriyoruz 
            return Ok(values);
        }

        [HttpPost] // ekleme işlemleri için kullanılan bir attributedir.
        public IActionResult CreateCategory(Category category)
        {                                                               //Swagger Aracı ile ekleme işlemini yapmış olduk.
            _context.Categories.Add(category);                          
            _context.SaveChanges();
            return Ok("Kategori ekleme işlemi başırılı");
        }
        [HttpDelete] //Silme işlemleri için kullanılan bir attributedir.
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id); // id den gelen değeri bul.
            _context.Categories.Remove(value); // valueden gelen değeri sil.
            _context.SaveChanges();
            return Ok("Kategori silme işlemi başarılı");
        }
        [HttpGet("GetCategory")] //ID ' ye göre getirme işlemi. // aynı attribute kullanılmaz bundan dolayı bir isim eklenir.
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return Ok(value);
        }
        [HttpPut]

        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori güncelleme başarılı");
        }

    }
}
