using Starcounter;
using System;

namespace AdfenixTestExamApp.DataAccess
{
    [Database]
    public class Home
    {
        public string Street { get; set; }

        public string Number { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Address => $"{Street}, {Number}, {ZipCode}, {City}, {Country}";

        public DateTime EntryDate { get; set; }

        public bool IsDelete { get; set; }

        //Relation
        public Franchise Franchise { get; set; }
    }
}
