using Starcounter;
using System;

namespace AdfenixTestExamApp.DataAccess
{
    [Database]
    public class Corporation
    {
        public string Name { get; set; }

        public DateTime EntryDate { get; set; }

        public bool IsDelete { get; set; }

        //Relation
        public QueryResultRows<Franchise> Franchises => Db.SQL<Franchise>("SELECT franchise FROM Franchise franchise WHERE franchise.Corporation = ?", this);
    }
}
