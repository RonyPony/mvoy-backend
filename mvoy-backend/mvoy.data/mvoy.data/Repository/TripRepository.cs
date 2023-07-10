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
    public class TripRepository : ITripRepository
    {
        private readonly MvoyContext _context;
        public TripRepository(MvoyContext ctx)
        {
            _context = ctx;
        }
        public async Task<Trip> CreateTrip(Trip trip)
        {
            try
            {
                _context.trips.Add(trip);
                await _context.SaveChangesAsync();
                return  trip;
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                return trip;
            }
        }

        public IEnumerable<Trip> getAllTrips()
        {
            return _context.trips.ToList().Where(e=>!e.isDeleted);
        }

        public async Task<Trip> getTripById(Guid id)
        {
            return await _context.trips.FindAsync(id);
        }

        public async Task<bool> RemoveTrip(Guid TripId)
        {
            try
            {
                Trip ci = await _context.trips.FindAsync(TripId);
                ci.isDeleted = true;
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

        public async Task<Trip> UpdateTrip(Trip Trip)
        {
            try
            {
                _context.trips.Update(Trip);
                await _context.SaveChangesAsync();
                return Trip;
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                return Trip;
            }
        }
    }
}
