using FutebolManager.Core.Interfaces;
using FutebolManager.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace FutebolManager.API.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class TimesController : ControllerBase
    {
        private readonly ITimeRepository _repository;

        public TimesController(ITimeRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Times        
        [HttpGet]        
        public async Task<IActionResult> GetAll()
        {
            var times = await _repository.GetAllAsync(); 
            return Ok(times);
        }

        // GET: api/Times/5        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var time = await _repository.GetByIdAsync(id);
            if (time == null)
            {
                return NotFound();
            }
            return Ok(time);
        }

        // POST: api/Times        
        [HttpPost]
        public async Task<IActionResult> Create(Time time)
        {
            await _repository.AddAsync(time);
            return CreatedAtAction(nameof(GetById), new { id = time.Id }, time);
        }

        // PUT: api/Times/5        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Time time)
        {
            if (id != time.Id) return BadRequest();

            await _repository.UpdateAsync(time);
            return NoContent();
        }

        // DELETE: api/Times/5        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
