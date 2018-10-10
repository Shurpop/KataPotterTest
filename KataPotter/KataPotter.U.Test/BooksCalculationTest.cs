using KataPotter.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace KataPotter.U.Test
{
    public class BooksCalculationTest
    {
        private BooksCalculation _booksCalculation;

        //All the books are different...
        public BooksCalculationTest()
        {
            this._booksCalculation = new BooksCalculation();
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
            //Assert of 5% and price ()
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
            //Assert of 5% and price ()
        }



        [Fact]
        public void DiscountOf_ThreeBooks()
        {
            //Assert of 10% and price ()
            throw new NotImplementedException();
        }

        [Fact]
        public void DiscountOf_FourBooks()
        {
            //Assert of 20% and price ()

            throw new NotImplementedException();
        }

        [Fact]
        public void DiscountOf_FiveBooks()
        {
            // Arrange
            var book = new Book { BookType = BookType.FirstBook };
           

            List<Book> books = new List<Book>() { book };

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            //Assert of 0% Price 8

            //Assert.Equal(8, price);


            throw new NotImplementedException();
        }

    }
}
