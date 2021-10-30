using System;
using System.Collections.Generic;

namespace Loans.models
{
    interface Model
    {
        public void loadData(string[] fields, Dictionary<string, Model[]> objects);
    }
}
