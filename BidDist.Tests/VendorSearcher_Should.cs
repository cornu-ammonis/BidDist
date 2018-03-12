﻿using System;
using Xunit;
using BidDist.Models;
using BidDist.Models.VendorViewModels;
using System.Collections.Generic;
using BidDist.Models.VendorRepository;

namespace BidDist.Tests
{
    public class VendorSearcher_Should
    {
        private List<Vendor> vendors;

        public VendorSearcher_Should()
        {
            vendors = VendorListGenerator.generateVendorsList();
        }

        [Fact]
        public void VendorSearcherSearchVendorsByStringReturnsPartialMatchForKeyword()
        {
            IList<Vendor> testListPartial = VendorSearcher.SearchVendorsByString(vendors, "key");

            bool validMatch = testListPartial.Count == 1 && testListPartial[0].KeyWords[0].Keyword.ToLower().Contains("key");

            Assert.True(validMatch, "vendor searcher search vendor by string should return a valid match according to keyword");
        }
    }
}