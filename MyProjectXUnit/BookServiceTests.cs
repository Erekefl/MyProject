using Microsoft.EntityFrameworkCore;
using MyProject.Models;
using MyProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectXUnit
{
    public class BookServiceTests
    {
        private readonly BookService bookService;
        private readonly ApplicationDbContext context;

      //public BookServiceTests()
      //  {
      //      // Настройка In-Memory Database для тестов
      //      var options = new DbContextOptionsBuilder<ApplicationDbContext>()
      //          .UseInMemoryDatabase(databaseName: "TestDatabase")
      //          .Options;

      //      // Создаем In-Memory контекст и передаем его в сервис
      //      context = new ApplicationDbContext(options);
      //      bookService = new BookService(_context); ;
      //  }

        //[Fact]
        //public void CreateBook_ShouldAddBook()
        //{
        //    // Arrange
        //    var book = new Book { Title = "C# Programming", AuthorId = 1, Pages = 300 };

        //    // Act
        //    var result = _bookService.CreateBook(book);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal("C# Programming", result.Title);
        //    Assert.Equal(300, result.Pages);
        //}



    }
}
