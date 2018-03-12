using System;
using Xunit;
using BidDist.Models;
using BidDist.Models.VendorViewModels;
using System.Collections.Generic;

namespace BidDist.Tests
{
    public class ListSortedVendorViewModel_Should
    {

        private ListSortedVendorViewModel listSortedVendorViewModel;

        public ListSortedVendorViewModel_Should()
        {
            // constructed with gnog filter as the search string because that wil result in reordering the list of vendors 
            // from its default ordering
            listSortedVendorViewModel = new ListSortedVendorViewModel(generateVendorsForViewModel(), "gnog filter");
        }
        [Fact]
        public void ListOfSortedVendorViewModelsIsSorted()
        {
            var result = IsSortedBySearchPoints(listSortedVendorViewModel.VendorViewModels);

            Assert.True(result, "ListSortedVendorViewModel's list should be sorted by search points");
        }

        private bool IsSortedBySearchPoints(List<VendorViewModel> sortedVendorViewModels)
        {

            for (int i = 0; i < sortedVendorViewModels.Count - 1; i++)
            {
                SortedVendorViewModel sortedVendorViewModelN = (SortedVendorViewModel)sortedVendorViewModels[i];
                SortedVendorViewModel sortedVendorViewModelNPlusOne = (SortedVendorViewModel)sortedVendorViewModels[i + 1];

                if (sortedVendorViewModelN.SearchPoints < sortedVendorViewModelNPlusOne.SearchPoints)
                    return false;
            }

            return true;
        }

        private List<Vendor> generateVendorsForViewModel()
        {
            var cities = new List<VendorCity>
            {
                new VendorCity {City = "Detroit"}
            };

            var citiesTwo = new List<VendorCity>
            {
                new VendorCity {City = "Detroit"}
            };

            var citiesThree = new List<VendorCity>
            {
                new VendorCity {City = "Detroit"}
            };

            var citiesFour = new List<VendorCity>
            {
                new VendorCity {City = "Detroit"}
            };

            var citiesFive = new List<VendorCity>
            {
                new VendorCity {City = "Detroit"}
            };

            var citiesSix = new List<VendorCity>
            {
                new VendorCity {City = "Detroit"}
            };


            var keyWordsOne = new List<VendorKeyword>
            {
                new VendorKeyword { Keyword = "Screws"},
                new VendorKeyword { Keyword = "Caulk" },
                new VendorKeyword { Keyword = "Bolts"}
            };

            var keyWordsTwo = new List<VendorKeyword>
            {
                new VendorKeyword { Keyword = "Sustainable"},
                new VendorKeyword { Keyword = "Filters" },
                new VendorKeyword { Keyword = "Air Filters"}
            };

            var keyWordsThree = new List<VendorKeyword>
            {
                new VendorKeyword { Keyword = "Screws"},
                new VendorKeyword { Keyword = "Caulk" },
                new VendorKeyword { Keyword = "Bolts"}
            };

            var keyWordsFour = new List<VendorKeyword>
            {
                new VendorKeyword { Keyword = "Sustainable"},
                new VendorKeyword { Keyword = "Filters" },
                new VendorKeyword { Keyword = "Gnog"},
                new VendorKeyword { Keyword = "Air Filters"}
            };

            var keyWordsSix = new List<VendorKeyword>
            {
                new VendorKeyword { Keyword = "Screws"},
                new VendorKeyword { Keyword = "Caulk" },
                new VendorKeyword { Keyword = "Bolts"}
            };

            var keyWordsFive = new List<VendorKeyword>
            {
                new VendorKeyword { Keyword = "Sustainable"},
                new VendorKeyword { Keyword = "Filters" },
                new VendorKeyword { Keyword = "Air Filters"}
            };

            var productsOne = new List<VendorProductCategory>
            {
                new VendorProductCategory { ProductCategory = "Screws"},
                new VendorProductCategory { ProductCategory = "Bolts"},
                new VendorProductCategory {ProductCategory = "Nails"}
            };

            var productsTwo = new List<VendorProductCategory>
            {
                new VendorProductCategory { ProductCategory = "Sprog"},
                new VendorProductCategory { ProductCategory = "Filters"},
                new VendorProductCategory {ProductCategory = "Filter Cleaning Service"}
            };

            var productsThree = new List<VendorProductCategory>
            {
                new VendorProductCategory { ProductCategory = "Screws"},
                new VendorProductCategory { ProductCategory = "Bolts"},
                new VendorProductCategory {ProductCategory = "Nails"}
            };

            var productsFour = new List<VendorProductCategory>
            {
                new VendorProductCategory { ProductCategory = "Air Filters"},
                new VendorProductCategory { ProductCategory = "Filters"},
                new VendorProductCategory {ProductCategory = "Filter Cleaning Service"}
            };

            var productsFive = new List<VendorProductCategory>
            {
                new VendorProductCategory { ProductCategory = "Screws"},
                new VendorProductCategory { ProductCategory = "Bolts"},
                new VendorProductCategory {ProductCategory = "Nails"}
            };

            var productsSix = new List<VendorProductCategory>
            {
                new VendorProductCategory { ProductCategory = "Air Filters"},
                new VendorProductCategory { ProductCategory = "Filters"},
                new VendorProductCategory {ProductCategory = "Filter Cleaning Service"}
            };


            var vendors = new Vendor[]
            {
                new Vendor{Name = "vendor one", Email = "vendor1@demo.com", IsLocal = true, Cities = cities, KeyWords = keyWordsOne, ProductCategories = productsOne },
                new Vendor{Name = "vendor two", Email = "vendor2@demo.com", IsLocal = true,  Cities = citiesTwo, KeyWords = keyWordsTwo, ProductCategories = productsTwo},
                new Vendor{Name = "vendor three", Email = "vendor3@demo.com", IsLocal = true, Cities = citiesThree, KeyWords = keyWordsThree, ProductCategories = productsThree },
                new Vendor{Name = "vendor four", Email = "vendor4@demo.com", IsLocal = true,  Cities = citiesFour, KeyWords = keyWordsFour, ProductCategories = productsFour},
                new Vendor{Name = "vendor five", Email = "vendor5@demo.com", IsLocal = true, Cities = citiesFive, KeyWords = keyWordsFive, ProductCategories = productsFive },
                new Vendor{Name = "vendor six", Email = "vendor6@demo.com", IsLocal = true,  Cities = citiesSix, KeyWords = keyWordsSix, ProductCategories = productsSix},
            };

            List<Vendor> list = new List<Vendor>();

            foreach (Vendor v in vendors)
                list.Add(v);

            return list;
            
        }
    }
}
