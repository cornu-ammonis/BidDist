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
            listSortedVendorViewModel = new ListSortedVendorViewModel(VendorListGenerator.generateVendorsForViewModel(), "gnog filter");
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

        
    }
}
