using DotNet.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public static List<Category> categoriesList = new List<Category>();
      [HttpGet]
        public IActionResult GetCategories()
        {
            categoriesList.Add(new Category() { Id = 1, Name = "Tech" });
            categoriesList.Add(new Category() { Id = 2, Name = "News" });
            categoriesList.Add(new Category() { Id = 3, Name = "Media" });
            categoriesList.Add(new Category() { Id = 3, Name = "Blog" });
            return Ok(categoriesList);
        }
        [HttpPost]
        public IActionResult PostCategories(Category category)
        {
            categoriesList.Add(category);
            return Ok();
        }
    }
}
