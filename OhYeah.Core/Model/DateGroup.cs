using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace OhYeah.Core.Model
{
    [DebuggerDisplay("Date: {Date}")]
    public class DateGroup<T> : List<T>, IComparable
    {
        public DateGroup():base(){}
        public DateGroup(IEnumerable<T> items) : base(items) { }
        public DateTime Date { get; set; }

        public int CompareTo(object obj)
        {
            var group = (DateGroup<T>) obj;

            return group.Date > this.Date ? 1 : 0;
        }

        public static IComparer<DateGroup<T>> SortByDate() => new SortByDateDescending();

        private class SortByDateDescending : IComparer<DateGroup<T>>
        {

            public int Compare(DateGroup<T> x, DateGroup<T> y)
            {
                var group1 = x;
                var group2 = y;

                if (group1.Date < group2.Date)
                    return 1;

                if (group1.Date > group2.Date)
                    return -1;

                return 0;
            }
        }
    }
}
