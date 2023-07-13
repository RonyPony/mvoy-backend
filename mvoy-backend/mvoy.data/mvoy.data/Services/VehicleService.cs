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
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repo;

        public VehicleService(IVehicleRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> DeleteVehicle(Guid vehicleId)
        {
            return _repo.RemoveVehicle(vehicleId);
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _repo.getAllVehicles();
        }

        public Task<Vehicle> GetVehicle(Guid vehicleId)
        {
            return _repo.getVehicle(vehicleId);
        }

        public Task<Vehicle> SaveVehicle(Vehicle vehicle)
        {
            return _repo.CreateVehicle(vehicle);
        }

        public Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            return _repo.UpdateVehicle(vehicle);
        }
    }
}
