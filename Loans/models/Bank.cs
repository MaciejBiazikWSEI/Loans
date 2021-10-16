using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.models
{
    class Bank : Model
    {
        public long Id { get; private set; }
        public string Name { get; private set; }

        public void loadData(string[] fields, Model[][] dependencies=null)
        {
            Id = long.Parse(fields[0]);
            Name = fields[1];
        }
    }
}
