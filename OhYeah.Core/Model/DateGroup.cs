using System;
using System.Collections.Generic;

namespace OhYeah.Core.Model
{
    public class DateGroup<T> : List<T>
    {
        public DateGroup():base(){}
        public DateGroup(IEnumerable<T> items) : base(items) { }
        public DateTime Date { get; set; }
    }
}
