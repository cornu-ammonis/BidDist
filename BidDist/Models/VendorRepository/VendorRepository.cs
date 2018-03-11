using BidDist.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidDist.Models.VendorRepository
{
    public class VendorRepository : IVendorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VendorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Vendor> ListVendorsBySearchString(String searchString)
        {
            return _dbContext.Vendors.ToList();
        }
    }
}
