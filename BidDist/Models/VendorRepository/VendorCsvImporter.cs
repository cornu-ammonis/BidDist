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

            for (int i = 1; i < rows.Count; i++)
                vendors.Add(CreateVendorFromRow(rows[i][nameColumn], rows[i][cityColumn], rows[i][keywordsColumn], rows[i][descriptionColumn]));

            return vendors;
        }

        private static Vendor CreateVendorFromRow(string name, string city, string keywords, string productDescription)
        {
            var cities = new List<VendorCity>
            {
                new VendorCity {City = city}
            };


            List<VendorKeyword> keywordsList = CreateVendorKeywordsListFromKeywords(keywords);


           
            
        }

        private static List<VendorKeyword> CreateVendorKeywordsListFromKeywords (string keywords)
        {
            List<VendorKeyword> keywordsList = new List<VendorKeyword>();
            string[] keywordsArray = keywords.Split(',');

            if (keywordsArray.Length > 1)
            {
                for (int i = 0; i < keywordsArray.Length; i++)
                    keywordsList.Add(new VendorKeyword { Keyword = keywordsArray[i] });
            }
            else
                keywordsList.Add(new VendorKeyword { Keyword = keywords });

            return keywordsList;
        }


    }
}
