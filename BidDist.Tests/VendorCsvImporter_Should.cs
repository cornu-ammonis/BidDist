using System;
using Xunit;
using BidDist.Models;
using BidDist.Models.VendorViewModels;
using System.Collections.Generic;
using BidDist.Models.VendorRepository;
using System.IO;
using System.Text;

namespace BidDist.Tests
{
    public class VendorCsvImporter_Should
    {
        private List<VendorViewModel> vendorViewModels;

        

        [Fact]
        public void VendorCsvGeneratorShouldCreateAVendorForEachRowOfInput()
        {
            String csv = "Name, Address, City, State, Keyword, Description, \r Test, test, test, test, test, test,\r test1, test1, test1, test1, test1, test1";
            List<Vendor> res = VendorCsvImporter.VendorCsvToListOfVendors(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(csv))));
            
            Assert.Equal(2, res.Count);
            //Assert.True(rowsEqualsViewModelCountPlusOne, "vendor csv generator should return a string with number of rows equal to inputted vendors + 1");
        }

       

       
    }
}
