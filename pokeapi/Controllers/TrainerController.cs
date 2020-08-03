using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using pokeapi.DataContext;
using pokeapi.Models;


namespace pokeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : Controller
    {
        private readonly AppDbContext _dbContext;

        Trainer trainer = new Trainer();

        public TrainerController(AppDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Trainer> Get()
        {
            var trainers = _dbContext.Trainers.ToList();
            return trainers;
        }

        // GET api/trainer/login?email=
        [HttpGet("login")]
        public ActionResult<Trainer> Get(string email)
        {
            try
            {
                var trainerFounded = _dbContext.Trainers.Where(d => d.Email == email).FirstOrDefault();
                if (trainerFounded == null)
                {
                    return NotFound();
                }
                return trainerFounded;
                
            } catch
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Trainer> Post([FromBody] Trainer newTrainer)
        {
            List<Trainer> trainers = _dbContext.Trainers.ToList();

            try
            {
                if (!trainers.Exists(d => d == newTrainer))
                {
                    trainer = _dbContext.Trainers.Add(newTrainer).Entity;
                }

                _dbContext.SaveChanges();

                return trainer;
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
