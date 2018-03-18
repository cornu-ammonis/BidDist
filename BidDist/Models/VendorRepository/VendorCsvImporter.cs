using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models.VendorRepository
{
    public static class VendorCsvImporter
    {
        public static List<Vendor> VendorCsvToListOfVendors(StreamReader vendorCsv)
        {
            List<string[]> rows = new List<string[]>();

            var parser = new CsvParser(vendorCsv);
            while (true)
            {
                string[] row = parser.Read();
                if (row == null)
                {
                    break;
                }

                rows.Add(row);
            }

            int nameColumn = 0;
            int cityColumn = 2;
            int keywordsColumn = 4;
            int descriptionColumn = 5;

            List<Vendor> vendors = new List<Vendor>();



            return vendors;
        }
    }
}
