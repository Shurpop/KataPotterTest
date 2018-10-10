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
        public void DiscountOfFirstBook()
        {
            // Arrange
            var book = new Book { BookType = BookType.FirstBook };
            List<Book> books = new List<Book>() { book };

            //Act
            _booksCalculation.GetPriceBooks(books);


            //Assert of 0% Price 8
        }

        [Fact]
        public void DiscountOfTwoBooks()
        {
            //Assert of 5% and price ()
        }

        [Fact]
        public void DiscountOfThreeBooks()
        {
            //Assert of 10% and price ()
        }

        [Fact]
        public void DiscountOfFourBooks()
        {
            //Assert of 20% and price ()
        }

        [Fact]
        public void DiscountOfFiveBooks()
        {
            //Assert of 20% and price ()
        }

    }
}
