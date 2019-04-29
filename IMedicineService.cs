using MedicineManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineManagmentSystem.Services
{
    public interface IMedicineService
    {
        Task<IEnumerable<Medicine>> Get();

        Task<Medicine> Get(string name);

        Task<bool> Add(Medicine medicine);

        Task Delete(string name);

        Task Update(Medicine oldMedicine, Medicine newMedicine );


    }
}
