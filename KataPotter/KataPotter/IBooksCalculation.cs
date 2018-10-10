using KataPotter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KataPotter
{
    public interface IBooksCalculation
    {
        decimal GetPriceBooks(List<Book> books);
    }
}
