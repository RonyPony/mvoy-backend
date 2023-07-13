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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly MvoyContext _context;

        public VehicleRepository(MvoyContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            Vehicle newVehicle = new Vehicle();
            try
            {
                _context.vehicles.Add(vehicle);
                await _context.SaveChangesAsync();
                return vehicle;
            }
            catch (Exception ex)
            {
                _context.ChangeTracker.Clear();
                return newVehicle;
            }
        }

        public IEnumerable<Vehicle> getAllVehicles()
        {
            return _context.vehicles.ToList();
        }

        public Task<Vehicle> getVehicle(Guid vehicleId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveVehicle(Guid VehicleId)
        {
                try
                {
                    Vehicle vehicle = await _context.vehicles.FindAsync(VehicleId);
                    _context.vehicles.Remove(vehicle);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }            
        }

        public Task<bool> UpdateVehicle(Vehicle Vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
