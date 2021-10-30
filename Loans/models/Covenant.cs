using System;
using System.Collections.Generic;
using System.Linq;

namespace Loans.models
{
    class Covenant : Model
    {
        public Facility Facility { get; private set; }
        public decimal? MaxDefaultLikelihood { get; private set; }
        public Bank Bank { get; private set; }
        public string BannedState { get; private set; }

        public void loadData(string[] fields, Dictionary<string, Model[]> objects)
        {
            var banks = objects["banks"] as Bank[];
            var facilities = objects["facilities"] as Facility[];

            Facility = facilities.Where((o) => o.Id == long.Parse(fields[0])).First();
            if(fields[1].Length > 1)
                MaxDefaultLikelihood = decimal.Parse(fields[1]);
            else
                MaxDefaultLikelihood = null;
            Bank = banks.Where((o) => o.Id == long.Parse(fields[2])).First();
            BannedState = fields[3];
        }
    }
}
