using KataPotter.Entities;
using KataPotter.Entities.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class BooksCalculation : IBooksCalculation
    {
        private readonly DiscountsDictionary _discountsPercentage;

        private const int priceBook = 8;

        public BooksCalculation()
        {
            _discountsPercentage = new DiscountsDictionary();
        }

        public decimal GetPriceBooks(List<Book> books)
        {
            if (!books.Any()) return 0;

            //get the number of different books vs number of equal books by type..
            var numOfDistinctBooks = books.Select(p => p.BookType).Distinct().Count();
            if (numOfDistinctBooks == books.Count)
            {
                //All books are different.
                var discount = this.GetDiscountOfBooks(numOfDistinctBooks);
                return (books.Count * priceBook) * discount;
            }

            //All books are repeated
            return CalculatePriceRepeatedBooks(books);
        }

        private decimal CalculatePriceRepeatedBooks(List<Book> books)
        {
            //TODO: refactor to handle 2 or n types of groups
            var repeatedBooks = GetCountOfRepeatedBooks(books);
            if (repeatedBooks > 1)
            {
                var diffBooks = books.Count - repeatedBooks;
                return (this.GetDiscountOfBooks(repeatedBooks) * priceBook * repeatedBooks) + (diffBooks * priceBook);
            }
           
            //Only exist one type
            return repeatedBooks * priceBook * books.Count;
        }


        private int GetCountOfRepeatedBooks(List<Book> books)
        {
            return books.GroupBy(p => p.BookType).Count();
        }

        private decimal GetDiscountOfBooks(int numDistintBooks)
        {
            BooksCombiDicounts combiDicounts = (BooksCombiDicounts)numDistintBooks;

            if (_discountsPercentage.discountDict.ContainsKey(combiDicounts))
            {
                return _discountsPercentage.discountDict[combiDicounts];
            }

            return 1;
        }

    }
}
