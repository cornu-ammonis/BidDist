using System;
using Xunit;
using BidDist.Models;
using BidDist.Models.VendorViewModels;
using System.Collections.Generic;
using BidDist.Models.VendorRepository;

namespace BidDist.Tests
{
    public class VendorCsvGenerator_Should
    {
        private List<VendorViewModel> vendorViewModels;

        public VendorCsvGenerator_Should()
        {
            vendorViewModels = VendorListGenerator.generateVendorViewModelList();
        }

        [Fact]
        public void VendorCsvGeneratorShouldCreateARowForEachVendorInput()
        {
           String csv = VendorsCsvGenerator.GenerateVendorCsv(vendorViewModels);

            bool rowsEqualsViewModelCountPlusOne = (csv.Split().Length == vendorViewModels.Count + 1);

            Assert.Equal(vendorViewModels.Count + 1, csv.Split('\r').Length);
            //Assert.True(rowsEqualsViewModelCountPlusOne, "vendor csv generator should return a string with number of rows equal to inputted vendors + 1");
        }

        [Fact]
        public void VendorCsvGeneratorShouldCreateHeaderRowAndSubsequentRowsOfEqualLength()
        {
            String[] csv = VendorsCsvGenerator.GenerateVendorCsv(vendorViewModels).Split('\r');

            bool eachRowIsEqualLength = csv.Length >= 2;

            int headerLength = csv[0].Split(',').Length - 1;

            for (int i = 1; i < csv.Length; i++)
            {
                bool isEscaped = false;
                int commaCount = 0;

                foreach (char c in csv[i])
                    if (c.Equals('\"'))
                        isEscaped = !isEscaped;
                    else if (c.Equals(',') && !isEscaped)
                        commaCount += 1;

                if (commaCount != headerLength)
                    eachRowIsEqualLength = false;
            }

            Assert.True(eachRowIsEqualLength, "Vendor Csv Generator should return a csv where column header (" + headerLength.ToString() +") and row length is equal \n" + 
                VendorsCsvGenerator.GenerateVendorCsv(vendorViewModels));

        }

       
    }
}
