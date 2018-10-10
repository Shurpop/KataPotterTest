using KataPotter.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace KataPotter.U.Test
{
    public class DifferentBooksCalculationTest
    {
        private readonly IBooksCalculation _booksCalculation;

        //All the books are different...
        public DifferentBooksCalculationTest()
        {
            _booksCalculation = new BooksCalculation();
        }

        [Fact]
        public void DiscountOf_NoBook()
        {
            //TODO: Improve with fluent buileder to add books with types...
            List<Book> books = new List<Book>();

            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(0, price);
        }

        [Fact]
        public void DiscountOf_OneBook()
        {
            // Arrange

            List<Book> books = new BooksBuilder()
                                .AddBook(BookType.FirstBook);

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            //Assert
            Assert.Equal(8, price);
        }

        [Fact]
        public void DiscountOf_TwoBooks()
        {
            // Arrange
            List<Book> books = new BooksBuilder()
                                .AddBook(BookType.FirstBook)
                                .AddBook(BookType.SecondBook);


            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(15.2m, price);
        }


        [Fact]
        public void DiscountOf_ThreeBooks()
        {
            // Arrange
            List<Book> books = new BooksBuilder()
                                .AddBook(BookType.FirstBook)
                                .AddBook(BookType.SecondBook)
                                .AddBook(BookType.ThirdBook);
            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(21.6m, price);
        }

        [Fact]
        public void DiscountOf_FourBooks()
        {
            List<Book> books = new BooksBuilder()
                                .AddBook(BookType.FirstBook)
                                .AddBook(BookType.SecondBook)
                                .AddBook(BookType.ThirdBook)
                                .AddBook(BookType.FourthBook);

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(25.6m, price);
        }

        [Fact]
        public void DiscountOf_FiveBooks()
        {
            List<Book> books = new BooksBuilder()
                     .AddBook(BookType.FirstBook)
                     .AddBook(BookType.SecondBook)
                     .AddBook(BookType.ThirdBook)
                     .AddBook(BookType.FourthBook)
                     .AddBook(BookType.FifthBook);

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(30, price);
        }

    }
}
