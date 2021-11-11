using Loans.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            printCsv(objects);

            return;
        }

        static T[] readCsv<T>(string filename, Dictionary<string, Model[]> objects) where T : Model, new()
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

        static void printCsv(Dictionary<string, Model[]> objects)
        {
            var loans = objects["loans"] as Loan[];
            var facilities = objects["facilities"] as Facility[];
            var banks = objects["banks"] as Bank[];
            var covenants = objects["covenants"] as Covenant[];

            using (var writer = new StreamWriter($"./assignments.csv"))
            {
                writer.WriteLine("loan_id, facility_id");
                foreach (Loan loan in loans)
                {
                    var id = loan.Id;

                    var restrictedFacilities = covenants
                        .Where((o) =>
                            o.MaxDefaultLikelihood > loan.DefaultLikeliHood
                            && o.Bank == o.Facility.Bank
                            && o.BannedState == loan.State
                        ).Select((o) => o.Facility);


                    try {
                        var facility = facilities
                            .Where((o) => o.Amount - o.CurrentAmount > loan.Amount * o.InterestRate)
                            .Except(restrictedFacilities)
                            .OrderBy((o) => o.Id)
                            .First();
                        
                        facility.CurrentAmount -= loan.Amount;
                        writer.WriteLine($"{loan.Id}, {facility.Id}");
                    } catch (InvalidOperationException) {
                        writer.WriteLine(",");
                    }
                }
            }
        }
    }
}
