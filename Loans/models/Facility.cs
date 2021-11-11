using System;
using System.Collections.Generic;
using System.Linq;

namespace Loans.models
{
    class Facility: Model
    {
        public decimal Amount { get; private set; }
        public decimal CurrentAmount { get; set; } = 0;
        public decimal InterestRate { get; private set; }
        public long Id { get; private set; }
        public Bank Bank { get; private set; }

        public void loadData(string[] fields, Dictionary<string, Model[]> objects)
        {
            var banks = objects["banks"] as Bank[];

            Amount = decimal.Parse(fields[0]);
            InterestRate = decimal.Parse(fields[1]);
            Id = long.Parse(fields[2]);
            Bank = banks.Where((o) => o.Id == long.Parse(fields[3])).First();
        }
    }
}
