﻿using KataPotter.Entities;
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
    }
}
