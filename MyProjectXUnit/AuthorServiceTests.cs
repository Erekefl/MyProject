using Moq;
using MyProject.Models;
using MyProject.Services;
using System.Data.Entity;

namespace MyProjectXUnit
{
    public class AuthorServiceTests
    {

        private readonly AuthorService authorService;
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly Mock<DbSet<Author>> _mockDbSet;


        public AuthorServiceTests()
        {
            // Настройка mock-объекта DbSet<Author>
            _mockDbSet = new Mock<DbSet<Author>>();

            // Настройка mock-объекта ApplicationDbContext
            _mockContext = new Mock<ApplicationDbContext>();
            _mockContext.Setup(m => m.Authors).Returns(_mockDbSet.Object);

            // Создаем экземпляр AuthorService с mock-контекстом
            authorService = new AuthorService(_mockContext.Object);
        }



        [Fact]
        public void CreateAuthor_ShouldAddAuthor()
        {
            // Arrange
            var author = new Author { Id = 1, Name = "Author 1", Age = 45 };

            // Настроить Mock, чтобы эмулировать добавление элемента в DbSet
            _mockDbSet.Setup(m => m.Add(It.IsAny<Author>())).Callback<Author>(a => _mockDbSet.Object.Add(a));

            // Act
            var result = authorService.CreateAuthor(author);

            // Assert
            _mockDbSet.Verify(m => m.Add(It.Is<Author>(a => a == author)), Times.Once); // Проверка, что Add был вызван
            Assert.Equal(author.Name, result.Name);
            Assert.Equal(author.Age, result.Age);
        }


        //[Fact]
        //public void GetAllAuthors_ShouldReturnAllAuthors()
        //{
        //    // Act
        //    var authors = authorService.GetAllAuthors();

        //    // Assert
        //    Assert.NotNull(authors);
        //    Assert.IsType<List<Author>>(authors);
        //}

        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //public void GetAuthorById_ShouldReturnCorrectAuthor(int authorId)
        //{
        //    // Act
        //    var author = authorService.GetAuthorById(authorId);

        //    // Assert
        //    Assert.NotNull(author);
        //    Assert.Equal(authorId, author.Id);
        //}

        //[Fact]
        //public void UpdateAuthor_ShouldModifyAuthor()
        //{
        //    // Arrange
        //    var existingAuthor = new Author { Id = 1, Name = "Original Name", Age = 45 };
        //    var updatedAuthor = new Author { Name = "Updated Name", Age = 50 };

        //    // Настройка поиска автора по Id
        //    _mockDbSet.Setup(m => m.FirstOrDefault(It.IsAny<System.Linq.Expressions.Expression<Func<Author, bool>>>()))
        //        .Returns(existingAuthor);

        //    // Act
        //    var result = authorService.UpdateAuthor(1, updatedAuthor);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal("Updated Name", result.Name);
        //    Assert.Equal(50, result.Age);

        //    // Проверка, что вызвался метод сохранения контекста
        //    _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        //}

        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //public void DeleteAuthor_ShouldRemoveAuthor(int authorId)
        //{
        //    // Act
        //    var result = authorService.DeleteAuthor(authorId);

        //    // Assert
        //    Assert.True(result);
        //}
    }
}