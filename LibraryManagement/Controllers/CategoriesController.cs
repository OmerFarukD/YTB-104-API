using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{

    ICategoryRepository categoryRepository = new CategoryRepository();




    [HttpPost("add")]
    public IActionResult Add(Category category)
    {
        categoryRepository.Add(category);

        return Ok("Kategori eklendi.");
    }


    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        List<Category> categories = categoryRepository.GetAll();

        return Ok(categories);
    }


}
