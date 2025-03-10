using LibraryManagement.Models.Dtos.Categories;

namespace LibraryManagement.Services.Abstracts;

public interface ICategoryService
{
    List<CategoryResponseDto> GetAll();

    void Add(CategoryAddRequestDto categoryAddRequestDto);

    void delete(int id);

    CategoryResponseDto? GetById(int id);
}
