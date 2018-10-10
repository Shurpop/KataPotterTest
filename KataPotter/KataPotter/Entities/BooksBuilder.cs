
using System.Collections.Generic;

namespace KataPotter.Entities
{
    public class BooksBuilder
    {
        private List<Book> _books = new List<Book>();

        public List<Book> Build()
        {
            return _books;
        }

        public BooksBuilder AddBook(BookType type)
        {
            _books.Add(new Book { BookType = type });
            return this;
        }

        public static implicit operator List<Book>(BooksBuilder instance)
        {
            return instance.Build();
        }

    }
}
