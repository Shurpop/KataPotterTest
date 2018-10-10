using KataPotter.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KataPotter.U.Test
{
    public class SameBooksCalculationTest
    {
        private readonly IBooksCalculation _booksCalculation;

        //All the books are the same...
        public SameBooksCalculationTest()
        {
            _booksCalculation = new BooksCalculation();
        }

        [Fact]
        public void DiscountOf_TwoBooks_Equal()
        {
            // Arrange
            var book = new Book { BookType = BookType.FirstBook };
            var book2 = new Book { BookType = BookType.FirstBook };
            List<Book> books = new List<Book>() { book, book2 };

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(16, price);
        }


        [Fact]
        public void DiscountOf_ThreeBooks_Equal()
        {
            // Arrange
            var book = new Book { BookType = BookType.FirstBook };
            var book2 = new Book { BookType = BookType.FirstBook };
            var book3 = new Book { BookType = BookType.FirstBook };
            List<Book> books = new List<Book>() { book, book2, book3 };

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(16, price);
        }

    }
}
