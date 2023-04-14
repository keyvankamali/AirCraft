using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aircraft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aircraft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirCraftController : ControllerBase
    {
        private readonly AirCarftDbContext _airCarftDbContext;

        public AirCraftController(AirCarftDbContext airCarftDbContext)
        {
            _airCarftDbContext = airCarftDbContext;
        }

        [HttpGet]
        [Route("GetAirCraft")]

        public async Task<IEnumerable<AirCraft>> GetAirCrafts()
        {
            return await _airCarftDbContext.AirCraft.ToListAsync();
        }

        
        [HttpGet]
        [Route("GetAirCraft/{id}")]
        public async Task<AirCraft> GetAirCrafts(int id)
        {
            var airCraft = _airCarftDbContext.AirCraft.Where(d => d.RegistrationNumber == id);

            return (AirCraft)airCraft;
        }

        [HttpPost]
        [Route("AddAirCraft")]

        public async Task<AirCraft> AddAirCraft(AirCraft aircraft)
        {
            _airCarftDbContext.AirCraft.Add(aircraft);
            await _airCarftDbContext.SaveChangesAsync();
            return aircraft;
        }

        [HttpDelete]
        [Route("DeleteAirCraft/{id}")]
        public bool DeleteAirCraft(int id)
        {
            bool available = false;
            var airCraft = _airCarftDbContext.AirCraft.Find(id);
            if (airCraft != null)
            {
                available = true;
                _airCarftDbContext.Entry(airCraft).State = EntityState.Deleted;
                _airCarftDbContext.SaveChanges();
            }

            else
            {
                available = false;
            }

            return available;
        }
    }
}

