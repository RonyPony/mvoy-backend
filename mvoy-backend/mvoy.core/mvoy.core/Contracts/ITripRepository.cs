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

        public IEnumerable<Trip> getTripByUserId(Guid userId);
        public Task<Trip> getTripByDriver(Guid id);
        /// <summary>
        /// Register a new record of Trip data.
        /// </summary>
        /// <param name="Trip">Trip's request</param>
        public Task<Trip> CreateTrip(Trip trip);

        /// <summary>
        /// Update a specific record of Trip data.
        /// </summary>
        /// <param name="Trip">Trip's request</param>
        /// 
        public Task<Trip> UpdateTrip(Trip Trip);


        /// <summary>
        ///  Remove a specific record of Trip data.
        /// </summary>
        /// <param name="Trip">Trip's request</param>
        public Task<bool> RemoveTrip(Guid TripId);

    }
}
