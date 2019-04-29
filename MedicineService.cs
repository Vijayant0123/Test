using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineManagmentSystem.Models;

namespace MedicineManagmentSystem.Services
{
    public class MedicineService : IMedicineService
    {
        static ConcurrentDictionary<string, Medicine> Medicines = new ConcurrentDictionary<string, Medicine>();
        public async Task<bool> Add(Medicine medicine)
        { 
            var result= await Task.FromResult(Medicines.TryAdd<string,Medicine>(medicine.Name,medicine));
            return result;
        }

        public async Task Delete(string name)
        {
            await Task.FromResult(Medicines.TryRemove(name, out Medicine deleted));
        }

        public async Task<IEnumerable<Medicine>> Get()
        {
           var result= await Task.FromResult(Medicines.Values);

            return result;
        }

        public async Task<Medicine> Get(string name)
        {
            Medicines.TryGetValue(name, out Medicine medicine);

            return await Task.FromResult(medicine);
        }

        public async Task Update(Medicine oldMedicine, Medicine newMedicine)
        {
            Medicines.TryUpdate(oldMedicine.Name, newMedicine, oldMedicine);
        }
    }
}
