using System;
using System.Collections.Generic;
using System.Globalization;

namespace Loans.models
{
    class Loan : Model
    {
        public decimal InterestRate { get; private set; }
        public decimal Amount { get; private set; }
        public long Id { get; private set; }
        public decimal DefaultLikeliHood { get; private set; }
        public string State { get; private set; }

        public void loadData(string[] fields, Dictionary<string, Model[]> objects)
        {
            InterestRate = decimal.Parse(fields[0], CultureInfo.InvariantCulture);
            Amount = decimal.Parse(fields[1], CultureInfo.InvariantCulture);
            Id = long.Parse(fields[2]);
            DefaultLikeliHood = decimal.Parse(fields[3], CultureInfo.InvariantCulture);
            State = fields[4];
        }
    }
}
