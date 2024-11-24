using System.Collections;
using System.Collections.Generic;

namespace MyProject.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public int Age { get; set; }

        public string surname { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}