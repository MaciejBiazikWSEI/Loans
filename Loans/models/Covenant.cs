using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.models
{
    class Covenant
    {
        public Facility Facility { get; set; }
        public decimal MaxDefaultLikelihood { get; set; }
        public Bank Bank { get; set; }
        public string BannedState { get; set; }
    }
}
