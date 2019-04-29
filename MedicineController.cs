using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicineManagmentSystem.Models;
using MedicineManagmentSystem.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicineManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    public class MedicineController : Controller
    {
        private readonly IMedicineService medicineService;
        public MedicineController(IMedicineService medicineService)
        {
            this.medicineService = medicineService;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result= await medicineService.Get();
            return Ok(result);
        }

        // GET api/<controller>/5
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var result = await medicineService.Get(name);
            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Medicine medicine)
        {
            var existingMedicine = await medicineService.Get(medicine.Name);
            if(existingMedicine != null)
            {
                return Conflict();
            }

            await medicineService.Add(medicine);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{name}")]
        public async Task<IActionResult> Put(string name, [FromBody]Medicine medicine)
        {
            var existingMedicine = await medicineService.Get(name);
           if(existingMedicine==null)
            {
                NotFound();
            }

            await medicineService.Update(existingMedicine, medicine);
            return Ok();

        }

        // DELETE api/<controller>/5
        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            await medicineService.Delete(name);
            return Ok();
        }
    }
}
