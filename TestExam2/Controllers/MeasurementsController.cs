using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestExam2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private static List<Measurement> measurements = new List<Measurement>();
        
        private ManageMeasurements manager = new ManageMeasurements();
        // GET: api/Measurements
        [HttpGet]
        public IEnumerable<Measurement> Get()
        {

            return measurements;


            /*  brugt i tilfælde at Databasen kom op og køre
             *  return manager.Get();
             */
        }

        // GET: api/Measurements/5
        [HttpGet("{id}", Name = "Get")]
        public Measurement Get(int id)
        {

            if (measurements.Exists(i=> i.Id == id))
            {
                return measurements.Find(i => i.Id == id);
            }

            return null;

            /*  brugt i tilfælde at Databasen kom op og køre
            *   return manager.Get(id);
            */
        }

        // POST: api/Measurements
        [HttpPost]
        public int Post([FromBody] Measurement measurement)
        {

            measurement.Timestamp = DateTime.Now;
            measurement.Id = measurements.Count + 1;
            measurements.Add(measurement);
            return measurement.Pressure;

            /* brugt i tilfælde at Databasen kom op og køre
             * manager.Post(measurement);
             */
        }

      

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            if (measurements.Exists(i=> i.Id == id))
            {
                measurements.Remove(measurements.Find(i => i.Id == id));
            }

            /* brugt i tilfælde at Databasen kom op og køre
             * manager.Delete(id);
             */
        }
    }
}
