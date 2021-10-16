using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.models
{
    class Facility
    {
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public long Id { get; set; }
        public Bank Bank { get; set; }
    }
}
