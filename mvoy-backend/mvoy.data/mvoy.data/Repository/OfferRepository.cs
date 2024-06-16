using mvoy.core.Contracts;
using mvoy.core.Models;
using mvoy.data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.data.Repository
{
    public class OfferRepository : IOfferRepository
    {
        private readonly MvoyContext _context;
        public OfferRepository(MvoyContext ctx)
        {
            _context = ctx;
        }
        public async Task<Offer> CreateOffer(Offer data)
        {
            try
            {
                _context.offers.Add(data);
                await _context.SaveChangesAsync();
                return  data;
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                return data;
            }
        }

        public IEnumerable<Offer> getAllOffers()
        {
            return _context.offers.ToList();
        }

        public List<Offer> getOfferById(Guid id)
        {
            return  _context.offers.Where((rr)=>rr.tripId==id).ToList();
        }

        public async Task<bool> RemoveOffer(Guid TripId)
        {
            try
            {
                Offer ci = await _context.offers.FindAsync(TripId);
               // ci.isDeleted = true;
                _context.Update(ci);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<Offer> UpdateOffer(Offer data)
        {
            try
            {
                _context.offers.Update(data);
                await _context.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                return data;
            }
        }
    }
}
