using BidDist.Models.VendorViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models.VendorRepository
{
    public static class VendorsCsvGenerator
    {
        public static String GenerateVendorCsv(List<VendorViewModel> vendorViewModels)
        {
            String csv = ColumnHeaders();

            foreach (VendorViewModel vvm in vendorViewModels)
            {
                csv += "\r\n";
                csv += "\"" + vvm.Name + "\"" + "," + vvm.Email + "," + "\"" + vvm.ProductCategories + "\"" + ",";
            }

            return csv;
        }

        private static String ColumnHeaders()
        {
            return "Name, Email, Product Categories,";
        }
    }
}
