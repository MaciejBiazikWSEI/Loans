using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.models
{
    interface Model
    {
        public void loadData(string[] fields, Model[][] dependencies);
    }
}
