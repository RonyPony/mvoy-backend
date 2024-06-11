using mvoy.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.core.Interface
{
    public interface ITripService
    {
        public IEnumerable<Trip> GetAllTrips();
        public Task<Trip> SaveTrip(Trip Trip);
        public Task<Trip> updateTrip(Trip Trip);
        public Task<bool> DeleteTrip(Guid TripId);
        public Task<Trip> getTripById(Guid TripId);
        public double getTripPriceByDistance(double km);
        public IEnumerable<Trip> getTripByUserId(Guid userId);
        public Task<Trip> getTripByDriver(Guid id);
    }
}
