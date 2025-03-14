using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Categories;
using LibraryManagement.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{

    private ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [HttpPost("add")]
    public IActionResult Add(CategoryAddRequestDto category)
    {
        _categoryService.Add(category);

        return Ok("Kategori eklendi.");
    }


    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        List<CategoryResponseDto> categories = _categoryService.GetAll();

        return Ok(categories);
    }


}
