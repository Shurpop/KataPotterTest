using KataPotter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class BooksCalculation
    {
        private const Int32 priceBook = 8;

        private const Decimal twoBooksDiscountFactor = 0.95m;
        private const Decimal threeBooksDiscountFactor = 0.90m;
        private const Decimal fourBooksDiscountFactor = 0.80m;
        private const Decimal fiveBooksDiscountFactor = 0.75m;

        public Decimal GetPriceBooks(List<Book> books)
        {
            decimal finalPrice = 0;

            if (!books.Any()) return finalPrice;

            //get the number of different books vs number of equal books by type..
            var numOfDistinctBooks = books.Select(p => p.BookType).Distinct().Count();
            if (numOfDistinctBooks == books.Count)
            {
                //All books are different.

                var discount = this.GetDiscountOfBooks(numOfDistinctBooks);

                return (books.Count * priceBook) * discount;
            }

            var repeated = GetCountOfRepeatedBooks(books);

            //Repeated..




            return 0;
        }

        private Int32 GetCountOfRepeatedBooks(List<Book> books)
        {
            return books.Count - books.GroupBy(p => p.BookType).Count();
        }

        private decimal GetDiscountOfBooks(Int32 numDistintBooks)
        {
            //TODO: Improve with a dictionary key value pair
            if (numDistintBooks == 2)
            {
                return twoBooksDiscountFactor;
            }
            else if (numDistintBooks == 3)
            {
                return threeBooksDiscountFactor;
            }
            else if (numDistintBooks == 4)
            {
                return fourBooksDiscountFactor;
            }
            else if (numDistintBooks == 5)
            {
                return fiveBooksDiscountFactor;
            }
            else
            {
                return 1;
            }

        }

    }
}
