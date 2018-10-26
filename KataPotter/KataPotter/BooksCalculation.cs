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

            // Get the number of different books vs number of equal books by type..
            var numOfDistinctBooks = GetCountOfDistinctBooks(books);
            
            if (numOfDistinctBooks == books.Count)
            {
                // All books are different.
                var discount = this.GetDiscountOfBooks(numOfDistinctBooks);
                return books.Count * priceBook * discount;
            }

            // Books repeated more than 1 time
            //var repeatedBooks
            //    = books.GroupBy(t => t.BookType).Where(p => p.Count() > 1).SelectMany(s => s).ToList();
            
            return CalculatePriceRepeatedBooks(books);
        }

        private decimal CalculatePriceRepeatedBooks(List<Book> books)
        {
            var repeatedBooks = GetCountOfRepeatedBooks(books);

            decimal totalResult = 0;
            if (repeatedBooks > 1)
            {
                //Type of n books repeated.
                var groupedBooks = books.GroupBy(p => p.BookType).ToList();
              
                foreach (var bundleBooks in groupedBooks)
                {
                    var discount = this.GetDiscountOfBooks(bundleBooks.Count());
                    totalResult += discount * priceBook * bundleBooks.Count();
                }

                //All books - All the repeated boocks
                var diffBooks = books.Count - groupedBooks.SelectMany(t => t).Count();
                return totalResult +(diffBooks * priceBook);
            }

            //Only exist one type
            return priceBook * books.Count;
        }


        private int GetCountOfRepeatedBooks(List<Book> books)
        {
            return books.GroupBy(p => p.BookType).Count();
        }

        private int GetCountOfDistinctBooks(List<Book> books)
        {
            return books.Select(p => p.BookType).Distinct().Count();
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
