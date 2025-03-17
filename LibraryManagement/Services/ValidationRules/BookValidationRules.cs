using LibraryManagement.Exceptions.Types;
using LibraryManagement.Models.Dtos.Books;


namespace LibraryManagement.Services.ValidationRules;

public class BookValidationRules
{

    public static void BookAddValidator(BookAddRequestDto dto)
    {
        List<string> errors = new List<string>();
     
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            errors.Add("Başlık alanı boş olamaz.");
        }

        if (dto.Title.Length < 2)
        {
            errors.Add("Başlık alanı minimum 2 karakterli olmalıdır.");
        }

        if (dto.Price <= 0)
        {
            errors.Add("Fiyat alanı 0 dan küçük veya eşit olamaz.");
        }

        if (dto.Page < 0)
        {
            errors.Add("Sayfa Sayısı alanı 0 dan küçük veya eşit olamaz.");
        }


        if (string.IsNullOrWhiteSpace(dto.Isbn))
        {
            errors.Add("Isbn alanı Boş olamaz.");
        }

        if(dto.Isbn.Length != 14)
        {
            errors.Add("Isbn numarası alanı 14 Karakter olmalıdır.");
        }


        if (errors.Count > 0)
        {
            throw new ValidationException(errors);
        }

    }

}
