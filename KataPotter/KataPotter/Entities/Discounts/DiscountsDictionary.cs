
using System.Collections.Generic;

namespace KataPotter.Entities.Discounts
{
    public class DiscountsDictionary
    {
        public IDictionary<BooksCombiDicounts, decimal> discountDict = new Dictionary<BooksCombiDicounts, decimal>()
        {
            {BooksCombiDicounts.TwoBooks, 0.95m},
            {BooksCombiDicounts.ThreeBooks, 0.90m},
            {BooksCombiDicounts.FourBooks,  0.80m},
            {BooksCombiDicounts.FiveBooks,  0.75m}
        };
    }

    public enum BooksCombiDicounts
    {
        TwoBooks = 2,
        ThreeBooks = 3,
        FourBooks = 4,
        FiveBooks = 5
    }
}
