using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.models
{
    class Loan
    {
        public decimal InterestRate { get; set; }
        public decimal Amount { get; set; }
        public long Id { get; set; }
        public decimal DefaultLikelyHood { get; set; }
        public string State { get; set; }
    }
}
