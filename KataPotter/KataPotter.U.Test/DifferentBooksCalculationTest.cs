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
            var book = new Book { BookType = BookType.FirstBook };
            List<Book> books = new List<Book>() { book };

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            //Assert
            Assert.Equal(8, price);
        }

        [Fact]
        public void DiscountOf_TwoBooks()
        {
            // Arrange
            var book = new Book { BookType = BookType.FirstBook };
            var book2 = new Book { BookType = BookType.SecondBook };
            List<Book> books = new List<Book>() { book, book2 };

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(15.2m, price);
        }


        [Fact]
        public void DiscountOf_ThreeBooks()
        {
            // Arrange
            var book = new Book { BookType = BookType.FirstBook };
            var book2 = new Book { BookType = BookType.SecondBook };
            var book3 = new Book { BookType = BookType.ThirdBook };

            List<Book> books = new List<Book>() { book, book2, book3 };

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(21.6m, price);
        }

        [Fact]
        public void DiscountOf_FourBooks()
        {
            var book = new Book { BookType = BookType.FirstBook };
            var book2 = new Book { BookType = BookType.SecondBook };
            var book3 = new Book { BookType = BookType.ThirdBook };
            var book4 = new Book { BookType = BookType.FourthBook };

            List<Book> books = new List<Book>() { book, book2, book3, book4 };

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(25.6m, price);
        }

        [Fact]
        public void DiscountOf_FiveBooks()
        {
            var book = new Book { BookType = BookType.FirstBook };
            var book2 = new Book { BookType = BookType.SecondBook };
            var book3 = new Book { BookType = BookType.ThirdBook };
            var book4 = new Book { BookType = BookType.FourthBook };
            var book5 = new Book { BookType = BookType.FifthBook };

            List<Book> books = new List<Book>() { book, book2, book3, book4, book5 };

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(30, price);
        }

    }
}
