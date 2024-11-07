using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.Services
{
    public class BookService
    {

        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();

        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        public Book CreateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book UpdateBook(int id, Book updateBook)
        {
            var existingBook = _context.Books.FirstOrDefault(book => book.Id == id);
            if (existingBook != null)
            {
                existingBook.Title = updateBook.Title;
                existingBook.Author = updateBook.Author;
                existingBook.AuthorId = updateBook.AuthorId;
                _context.SaveChanges();
            }
            return existingBook;      
           

        }
        public bool DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

     

        

       

       
    }
}