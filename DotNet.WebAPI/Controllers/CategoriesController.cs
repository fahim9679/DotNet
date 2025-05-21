using DotNet.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //public static List<Category> categoriesList = new List<Category>();
        [HttpGet]
        public IActionResult GetCategories()
        {
            //if (categoriesList.Count == 0)
            //{
            //    categoriesList.Add(new Category() { Id = 1, Name = "Tech" });
            //    categoriesList.Add(new Category() { Id = 2, Name = "News" });
            //    categoriesList.Add(new Category() { Id = 3, Name = "Media" });
            //    categoriesList.Add(new Category() { Id = 4, Name = "Blog" });
            //}
            //return Ok(categoriesList);
            return Ok();
        }
        [HttpPost]
        public IActionResult PostCategories(Category category)
        {
            //categoriesList.Add(category);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult PutCategories(int id, Category category)
        {
            //var categoryToUpdate = categoriesList.FirstOrDefault(c => c.Id == id);
            //categoryToUpdate.Id = id;
            //categoryToUpdate.Name = category.Name;
            //return Ok(categoryToUpdate);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult PDeleteCategories(int id)
        {
            //var categoryToDelete = categoriesList.FirstOrDefault(c => c.Id == id);
            //categoriesList.Remove(categoryToDelete);
            return Ok();
        }
    }
}
