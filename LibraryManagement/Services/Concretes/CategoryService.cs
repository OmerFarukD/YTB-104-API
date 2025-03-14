using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.DataAccess.Concretes;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos.Categories;
using LibraryManagement.Services.Abstracts;

namespace LibraryManagement.Services.Concretes;

public class CategoryService : ICategoryService
{

    private ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void Add(CategoryAddRequestDto categoryAddRequestDto)
    {
        Category category = ConvertToCategory(categoryAddRequestDto);
        _categoryRepository.Add(category);
    }

    public void delete(int id)
    {
        Category category = _categoryRepository.GetById(id);
        _categoryRepository.Delete(category);
    }

    
    public List<CategoryResponseDto> GetAll()
    {
        List<Category> categories = _categoryRepository.GetAll();
        List<CategoryResponseDto> responses = ConvertToResponseDtoList(categories);
        return responses;
    }

    public CategoryResponseDto? GetById(int id)
    {
        Category category = _categoryRepository.GetById(id);
        CategoryResponseDto response = ConvertToResponseDto(category);

        return response;
    }

    private List<CategoryResponseDto> ConvertToResponseDtoList(List<Category> categories)
    {
        //List<CategoryResponseDto> responses = new();
        //foreach (Category category in categories)
        //{
        //    CategoryResponseDto response = ConvertToResponseDto(category);
        //    responses.Add(response);
        //}
        return categories.Select(x=> ConvertToResponseDto(x)).ToList();
    }

    private CategoryResponseDto ConvertToResponseDto(Category category)
    {
        return new CategoryResponseDto {Id = category.Id, Name=category.Name };
    }
    private Category ConvertToCategory(CategoryAddRequestDto dto)
    {
        return new Category { Name = dto.Name };
    }
}
