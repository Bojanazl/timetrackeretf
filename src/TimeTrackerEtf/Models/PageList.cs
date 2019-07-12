using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTrackerEtf.Models
{
    public class PageList<T>
    {

        public IEnumerable<T>Items { get; set; }

        public int Page { get; set; } //trenutna stranica

        public int PageSize { get; set; } //koliko itema stranca vraca

        public int TotalCount { get; set; } //vraca PageSize

        public int TotalPages =>
            (int) Math.Ceiling (TotalCount / (decimal) PageSize); //koliko ukupno ima stranica. Paginacija.
    }
}
