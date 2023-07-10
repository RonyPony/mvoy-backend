using mvoy.core.Contracts;
using mvoy.core.Interface;
using mvoy.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.data.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _repo;

        public TripService(ITripRepository rep)
        {
            _repo = rep;
        }
        public Task<bool> DeleteTrip(Guid TripId)
        {
            return _repo.RemoveTrip(TripId);
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            return _repo.getAllTrips();
        }

        public Task<Trip> getTripById(Guid TripId)
        {
            return _repo.getTripById(TripId);
        }

        public Task<Trip> SaveTrip(Trip Trip)
        {
            return _repo.CreateTrip(Trip);  
        }

        public Task<Trip> updateTrip(Trip Trip)
        {
            return _repo.UpdateTrip(Trip);
        }
    }
}
