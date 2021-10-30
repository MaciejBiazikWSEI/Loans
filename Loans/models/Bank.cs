using System;
using System.Collections.Generic;

namespace Loans.models
{
    class Bank : Model
    {
        public long Id { get; private set; }
        public string Name { get; private set; }

        public void loadData(string[] fields, Dictionary<string, Model[]> objects)
        {
            Id = long.Parse(fields[0]);
            Name = fields[1];
        }
    }
}
