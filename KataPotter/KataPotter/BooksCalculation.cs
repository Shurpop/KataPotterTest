using KataPotter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPotter
{
    public class BooksCalculation
    {
        private const Int32 priceBook = 8;

        public Decimal GetPriceBooks(List<Book> books)
        {
            //get the number of different books vs number of equal books by type..

          


            return 0;
        }

        private Int32 GetNumberOfRepeatedBooks(List<Book> books)
        {
            int numOfEqualBooks = books.GroupBy(p => p.BookType).Count();
        }


    }
}
