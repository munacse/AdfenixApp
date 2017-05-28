using Starcounter;
using System;

namespace AdfenixTestExamApp.DataAccess
{
    [Database]
    public class Sale
    {
        public long Price { get; set; }

        public long Commission { get; set; }

        public DateTime SalesDate { get; set; }

        public DateTime EntryDate { get; set; }

        public bool IsDelete { get; set; }

        //Relation
        public Franchise Franchise { get; set; }

        public Home Home { get; set; }
    }
}
