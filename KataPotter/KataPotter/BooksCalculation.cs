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

        private const Int32 priceBook = 8;

        public BooksCalculation()
        {
            _discountsPercentage = new DiscountsDictionary();
        }

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

            var repeatedBooks = GetCountOfRepeatedBooks(books);

            //All books are repeated
            if(repeatedBooks == 1)
            {
                finalPrice =  repeatedBooks * priceBook * books.Count;
            }
            else
            {
                var diffBooks = books.Count - repeatedBooks;
                finalPrice = (this.GetDiscountOfBooks(repeatedBooks) * priceBook * repeatedBooks) + (diffBooks * priceBook);
            }
            return finalPrice;
        }


        private Int32 GetCountOfRepeatedBooks(List<Book> books)
        {
            return books.GroupBy(p => p.BookType).Count();
        }

        private decimal GetDiscountOfBooks(Int32 numDistintBooks)
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
