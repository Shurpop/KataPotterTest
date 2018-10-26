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
            List<Book> books = new BooksBuilder()
                                 .AddBook(BookType.FirstBook)
                                 .AddBook(BookType.FirstBook)
                                 .AddBook(BookType.SecondBook);

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(23.2m, price);
        }

        [Fact]
        public void DiscountOf_TwoEqualBooks_Plus_TowEqualsBooks()
        {
            // Arrange
            List<Book> books = new BooksBuilder()
                                 .AddBook(BookType.FirstBook)
                                 .AddBook(BookType.FirstBook)
                                 .AddBook(BookType.SecondBook)
                                 .AddBook(BookType.SecondBook);
            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            //assert 2 * (8 * 2 * 0.95)
            //var dec = 2 * (8 * 2 * 0.95);

            Assert.Equal(30.4m, price); 
            //Calculation of groups by type is incorrect :(
        }

        [Fact]
        public void DiscountOf_TwoEqualBooks_Plus_TowEqualsBooks_PlushTwoEqualsBooks()
        {
            // Arrange
            List<Book> books = new BooksBuilder()
                                 .AddBook(BookType.FirstBook)
                                 .AddBook(BookType.FirstBook)
                                 .AddBook(BookType.SecondBook)
                                 .AddBook(BookType.SecondBook)
                                 .AddBook(BookType.ThirdBook)
                                 .AddBook(BookType.ThirdBook);
            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            //assert 3 * (8 * 2 * 0.95)
            Assert.Equal(45.6m, price);
            //Calculation of groups by type is incorrect :(
        }



        [Fact]
        public void ManyBooks_GetsBestPrice()
        {
            // Arrange
            List<Book> books = new BooksBuilder()
                                 .AddBook(BookType.FirstBook)
                                 .AddBook(BookType.FirstBook)
                                 .AddBook(BookType.SecondBook)
                                 .AddBook(BookType.SecondBook)
                                 .AddBook(BookType.ThirdBook)
                                 .AddBook(BookType.ThirdBook)
                                 .AddBook(BookType.FourthBook)
                                 .AddBook(BookType.FifthBook);

            //Act
            var price = _booksCalculation.GetPriceBooks(books);

            Assert.Equal(51.2m, price);
        }

    }
}
