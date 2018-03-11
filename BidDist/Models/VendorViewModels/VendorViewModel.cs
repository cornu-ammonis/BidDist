using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models.VendorViewModels
{
    
    public abstract class VendorViewModel
    {

        public String Name { get; set; }
        public String Email { get; set; }
        public String ProductCategories { get; set; }



        public VendorViewModel(Vendor vendor)
        {
            Name = vendor.Name;
            Email = vendor.Email;
            ProductCategories = ProductCategoriesToString(vendor.ProductCategories);
        }


        String ProductCategoriesToString(List<VendorProductCategory> productCategories)
        {
            String result = "";

            foreach (VendorProductCategory vpc in productCategories)
            {
                if (result.Length > 0)
                    result += vpc.ProductCategory + ", ";
                else
                    result += vpc.ProductCategory;
            }

            return result;
        }
    }
}
