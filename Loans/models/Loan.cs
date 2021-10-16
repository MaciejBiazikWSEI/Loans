using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.models
{
    class Loan : Model
    {
        public decimal InterestRate { get; private set; }
        public decimal Amount { get; private set; }
        public long Id { get; private set; }
        public decimal DefaultLikeliHood { get; private set; }
        public string State { get; private set; }

        public void loadData(string[] fields, Model[][] dependencies = null)
        {
            InterestRate = decimal.Parse(fields[0].Replace('.', ','));
            Amount = decimal.Parse(fields[1].Replace('.', ','));
            Id = long.Parse(fields[2]);
            DefaultLikeliHood = decimal.Parse(fields[3].Replace('.', ','));
            State = fields[4];
        }
    }
}
