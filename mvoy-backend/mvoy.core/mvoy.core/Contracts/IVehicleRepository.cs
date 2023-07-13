using mvoy.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.core.Contracts
{
    public interface IVehicleRepository
    {
        /// <summary>
        /// Register a new record of vehicle data.
        /// </summary>
        /// <param name="vehicle">vehicle's request</param>
        public Task<Vehicle> CreateVehicle(Vehicle Vehicle);

        public IEnumerable<Vehicle> getAllVehicles();

        public Task<Vehicle> getVehicle(Guid vehicleId);

        /// <summary>
        /// Update a specific record of vehicle data.
        /// </summary>
        /// <param name="vehicle">vehicle's request</param>
        public Task<bool> UpdateVehicle(Vehicle Vehicle);

        /// <summary>
        ///  Remove a specific record of vehicle data.
        /// </summary>
        /// <param name="vehicle">vehicle's request</param>
        public Task<bool> RemoveVehicle(Guid VehicleId);
    }
}
