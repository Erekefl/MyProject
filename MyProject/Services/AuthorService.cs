using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyProject.Services
{

    public class AuthorService
    {
        private readonly ApplicationDbContext _context;


        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public AuthorService()
        {
        }

        public List<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors
                .FirstOrDefault(x => x.Id == id);
        }


        public Author CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public Author UpdateAuthor(int id, Author updateAuthor)
        {
            var existingAuthor = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (existingAuthor != null)
            {
                existingAuthor.Name = updateAuthor.Name;
                existingAuthor.Age = updateAuthor.Age;
                _context.SaveChanges();
            }
            return existingAuthor;


        }

        public bool DeleteAuthor(int id)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Id == id);

            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
                return true;
            }
            return false;
            {
                
            }
        }

       
    }
}