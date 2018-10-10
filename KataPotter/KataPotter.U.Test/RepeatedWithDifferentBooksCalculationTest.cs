using KataPotter.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KataPotter.U.Test
{
    public class RepeatedWithDifferentBooksCalculationTest
    {
        private readonly IBooksCalculation _booksCalculation;

        public RepeatedWithDifferentBooksCalculationTest()
        {
            _booksCalculation = new BooksCalculation();
        }

        [Fact]
        public void DiscountOf_TwoEqualBooks_PlusOne()
        {
            // Arrange
            var book = new Book { BookType = BookType.FirstBook };
            var book2 = new Book { BookType = BookType.FirstBook };
            var book3 = new Book { BookType = BookType.SecondBook };
            List<Book> books = new List<Book>() { book, book2, book3 };

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(16, price);
        }
    }
}
