using mvoy.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvoy.core.Interface
{
    public interface IVehicleService
    {
        public IEnumerable<Vehicle> GetAllVehicles();
        public Task<Vehicle> SaveVehicle(Vehicle vehicle);
        public Task<Vehicle> GetVehicle(Guid vehicleId);
        public Task<bool> DeleteVehicle(Guid vehicleId);
        public Task<bool> UpdateVehicle(Vehicle vehicle);
    }
}
