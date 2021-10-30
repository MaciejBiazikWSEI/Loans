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
            var objects = new Dictionary<string, Model[]>();
            objects.Add("banks", readCsv<Bank>("banks", objects));
            objects.Add("loans", readCsv<Loan>("loans", objects));
            objects.Add("facilities", readCsv<Facility>("facilities", objects));
            objects.Add("covenants", readCsv<Covenant>("covenants", objects));

            return;
        }

        static T[] readCsv<T>(string filename, Dictionary<string, Model[]> objects) where T: Model, new()
        {
            var objs = new List<T>();


            // TODO: small -> large
            using (var reader = new StreamReader($"./zadanie/small/{filename}.csv"))
            {
                // skip first line
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var fields = line.Split(',');

                    var obj = new T();
                    obj.loadData(fields, objects);

                    objs.Add(obj);
                }
            }

            return objs.ToArray();
        }
    }
}
