using BidDist.Data;
using Microsoft.EntityFrameworkCore;
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

        public IList<Vendor> ListVendorsForUserBySearchString(String searchString, ApplicationUser user)
        {
            IList<Vendor> vendors;

            if (user.Email == "andrewjones232@gmail.com")
                vendors = (from v in _dbContext.Vendors select v).Include<Vendor, List<VendorKeyword>>(v => v.KeyWords)
                    .Include<Vendor, List<VendorProductCategory>>(v => v.ProductCategories).ToList();
            else
                vendors = new List<Vendor>();

            return VendorSearcher.SearchVendorsByString(vendors, searchString);

        }

        public int AddVendorListToDatabase (List<Vendor> vendors )
        {
            int newAdded = 0;

            foreach (Vendor v in vendors)
            {
                // note in the future should implement an equals method for vendor which allows more nuanced detection of duplicates
                if (! _dbContext.Vendors.Any(dbv => dbv.Name.Equals(v.Name) && dbv.Cities[0].City.Equals(v.Cities[0].City)))
                {
                    _dbContext.Vendors.Add(v);
                    newAdded++;
                }
            }

            _dbContext.SaveChanges();
            return newAdded;
        }

        
    }
}
