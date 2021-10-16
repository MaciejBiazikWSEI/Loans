using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.models
{
    class Facility: Model
    {
        public decimal Amount { get; private set; }
        public decimal InterestRate { get; private set; }
        public long Id { get; private set; }
        public Bank Bank { get; private set; }

        public void loadData(string[] fields, Model[][] dependencies)
        {
            if (dependencies.Length < 1 || !(dependencies[0] is Bank[]))
                throw new ArgumentException("Facility depends on Bank");

            Bank[] banks = dependencies[0] as Bank[];

            Amount = decimal.Parse(fields[0].Replace('.', ','));
            InterestRate = decimal.Parse(fields[1].Replace('.', ','));
            Id = long.Parse(fields[2]);
            // Bank = banks.
        }
    }
}
