﻿using LibraryManagement.Models;

namespace LibraryManagement.DataAccess.Abstracts;

public interface IBookRepository
{

    void Add(Book book);

    void Update(Book book);

    void Delete(Book book);

    List<Book> GetAll();

    Book? GetById(int id);

    Book? GetByIsbn(string isbn);

    List<Book> GetAllByPriceRange(double min , double max);

}
