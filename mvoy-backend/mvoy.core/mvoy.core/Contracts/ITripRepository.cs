using mvoy.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.core.Contracts
{
    public interface ITripRepository
    {
        public IEnumerable<Trip> getAllTrips();
        public Task<Trip> getTripById(Guid id);
        public Task<Trip> getTripBydriver(Guid id);
        public Task<Trip> getTripByClient(Guid id);
        public Task<Trip> CreateTrip(Trip trip);
        public Task<Trip> UpdateTrip(Trip Trip);
        public Task<bool> RemoveTrip(Guid TripId);

    }
}
