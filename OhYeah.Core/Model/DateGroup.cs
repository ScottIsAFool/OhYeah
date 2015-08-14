using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OhYeah.Core.Model
{
    [DebuggerDisplay("Date: {Date}")]
    public class DateGroup<T> : List<T>
    {
        public DateGroup():base(){}
        public DateGroup(IEnumerable<T> items) : base(items) { }
        public DateTime Date { get; set; }
    }
}
