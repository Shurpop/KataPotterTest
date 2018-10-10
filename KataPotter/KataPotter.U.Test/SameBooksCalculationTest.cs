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
            List<Book> books = new BooksBuilder()
                                 .AddBook(BookType.FirstBook)
                                 .AddBook(BookType.FirstBook);

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(16, price);
        }


        [Fact]
        public void DiscountOf_ThreeBooks_Equal()
        {
            // Arrange
            List<Book> books = new BooksBuilder()
                                 .AddBook(BookType.FirstBook)
                                 .AddBook(BookType.FirstBook)
                                 .AddBook(BookType.FirstBook);

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(24, price);
        }

    }
}
