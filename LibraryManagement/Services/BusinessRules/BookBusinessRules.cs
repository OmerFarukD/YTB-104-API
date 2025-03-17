using LibraryManagement.DataAccess.Abstracts;
using LibraryManagement.Exceptions.Types;
using LibraryManagement.Models;

namespace LibraryManagement.Services.BusinessRules;

public class BookBusinessRules
{
    private IBookRepository _bookRepository;

    public BookBusinessRules(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }



    public void TitleMustBeUnique(string title)
    {
        bool isPresentTitle = _bookRepository.IsPresentByTitle(title);

        if (isPresentTitle)
        {
            throw new BusinessException("Kitap başlığı Benzersiz olmalıdır.");
        }

    }


    public void IsbnMustBeUnique(string isbn)
    {
        bool countByIsbn = _bookRepository.IsPresentByIsbn(isbn);
        if (countByIsbn)
        {
            throw new BusinessException("Kitap Isbn numarası Benzersiz olmalıdır.");
        }
    }


    public void BookNotFound(Book? book)
    {
        if (book is null)
        {
            throw new NotFoundException("İlgili Kitap bulunamadı.");
        }
    }
}
