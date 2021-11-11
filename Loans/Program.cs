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
            try {
                objects.Add("banks", readCsv<Bank>("banks", objects));
                objects.Add("loans", readCsv<Loan>("loans", objects));
                objects.Add("facilities", readCsv<Facility>("facilities", objects));
                objects.Add("covenants", readCsv<Covenant>("covenants", objects));
            } catch (FileNotFoundException e) {
                Console.Error.WriteLine($"File {e.FileName} not found.");
                return;
            }

            printCsv(objects);

            return;
        }

        static T[] readCsv<T>(string filename, Dictionary<string, Model[]> objects) where T : Model, new()
        {
            var objs = new List<T>();

            using (var reader = new StreamReader($"./{filename}.csv"))
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
            // Deconstruct the objects dictionary for readability
            var loans = objects["loans"] as Loan[];
            var facilities = objects["facilities"] as Facility[];
            var banks = objects["banks"] as Bank[];
            var covenants = objects["covenants"] as Covenant[];

            using (var writer = new StreamWriter($"./assignments.csv"))
            {
                writer.WriteLine("loan_id, facility_id, total_cost");
                foreach (Loan loan in loans)
                {
                    // Find facilities resticted by covenants that would apply to this loan
                    var restrictedFacilities = covenants
                        .Where((o) =>
                            o.MaxDefaultLikelihood > loan.DefaultLikeliHood
                            && o.Bank == o.Facility.Bank
                            && o.BannedState == loan.State
                        ).Select((o) => o.Facility);

                    try {
                        // Find first facility that can still support the loan and isn't restricted by above covenants
                        var facility = facilities
                            .Where((o) => o.Amount - o.CurrentAmount > loan.Amount * o.InterestRate)
                            .Except(restrictedFacilities)
                            .First();
                        
                        // Update the facility information
                        facility.CurrentAmount += loan.Amount * facility.InterestRate;

                        var totalCost = loan.Amount +
                                        loan.Amount * loan.InterestRate +
                                        loan.Amount * facility.InterestRate;

                        // Write the facility in the file
                        writer.WriteLine($"{loan.Id}, {facility.Id}, {totalCost}");
                    } catch (InvalidOperationException) {
                        // If no matching facilities were found, write the loan id only
                        writer.WriteLine($"{loan.Id},,");
                    }
                }
            }
        }
    }
}
