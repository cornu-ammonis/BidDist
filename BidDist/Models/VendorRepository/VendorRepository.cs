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

        public IList<Vendor> ListVendorsBySearchString(String searchString, ApplicationUser user)
        {
            IList<Vendor> vendors = VendorsToSearchForUser(user);

            String[] searchStrings = searchString.Split(null);
            Console.WriteLine(searchStrings[0]);

            IEnumerable<Vendor> vendor_query =
                (from v in _dbContext.Vendors
                 where v.KeyWords.Any( k => searchStrings.Any(s =>  s.ToLower().Contains( k.Keyword.ToLower() ) || k.Keyword.ToLower().Contains( s.ToLower() )) )
                 || v.ProductCategories.Any( pc => searchStrings.Any(s => s.ToLower().Contains( pc.ProductCategory.ToLower() ) || pc.ProductCategory.ToLower().Contains( s.ToLower()) ) )
                 select v
                 );

            List<Vendor> resultingVendors = new List<Vendor>();
            foreach (Vendor v in vendor_query)
            {
                resultingVendors.Add(v);
            }

            return resultingVendors;

        }


        private IList<Vendor> VendorsToSearchForUser(ApplicationUser user)
        {
            if (user.Email == "andrewjones232@gmail.com")
                return (from v in _dbContext.Vendors select v).Include<Vendor, List<VendorKeyword>>(v => v.KeyWords).ToList();
            else
                return new List<Vendor>();
        }
        
    }
}
