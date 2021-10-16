using Loans.models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Loans
{
    class Program
    {
        static void Main(string[] args)
        {
            var banks = readCsv<Bank>("banks");
            var loans = readCsv<Loan>("loans");
            return;
        }

        static List<T> readCsv<T>(string filename) where T: Model, new()
        {
            var objs = new List<T>();


            // TODO: small -> large
            using (var reader = new StreamReader($".\\zadanie\\small\\{filename}.csv"))
            {
                // skip first line
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var fields = line.Split(',');

                    var obj = new T();
                    obj.loadData(fields, null);

                    objs.Add(obj);
                }
            }

            return objs;
        }
    }
}
