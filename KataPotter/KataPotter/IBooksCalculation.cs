using KataPotter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KataPotter
{
    public interface IBooksCalculation
    {
        Decimal GetPriceBooks(List<Book> books);
    }
}
