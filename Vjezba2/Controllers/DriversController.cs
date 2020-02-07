using System.Collections.Generic;
using System.Threading.Tasks;
using Metrics;
using Microsoft.AspNetCore.Mvc;
using Vjezba2.Models;

namespace Vjezba2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : Controller
    {
        
        private readonly IDriversRepository driversRepository;

        public DriversController(IDriversRepository driversRepository) => this.driversRepository = driversRepository;

        //Metrics 
        private readonly Timer timerGet = Metric.Timer("DriversController.GetDriver", Unit.Requests);
        private readonly Timer timerPut = Metric.Timer("DriversController.Post", Unit.Requests);



        // GET: api/Drivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> Get()
        {
            var drivers = await driversRepository.GetAll();
            return Ok(drivers);
        }

        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(int id)
        {
            using (var context = timerGet.NewContext(id.ToString()))
            {
                var driver = await driversRepository.Get(id);
                if (driver == null)
                    return NotFound();
                return driver;
            }
        }

        // PUT: api/Drivers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Driver driver)
        {
            
                if (id != driver.Id)
                    return BadRequest();
                var success = await driversRepository.Update(driver);
                if (!success)
                    return NotFound();
                return NoContent();
            
                
        }

        // POST: api/Drivers
        [HttpPost]
        public async Task<ActionResult<Driver>> Post(Driver driver)
        {
            using (var context = timerPut.NewContext(driver.ToString()))
            {
                if (driver.Money <= 0)
                    return BadRequest();
                var success = await driversRepository.Create(driver);
                if (success)
                    return CreatedAtAction("GetDriver", new { id = driver.Id }, driver);
                return BadRequest();
            }
        }

        // DELETE: api/Drivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await driversRepository.Delete(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}