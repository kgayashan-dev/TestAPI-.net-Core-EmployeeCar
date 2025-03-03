using Microsoft.AspNetCore.Mvc;
using WebApiEmployeeCar.Models;
using WebApiEmployeeCar.Repositories;

namespace WebApiEmployeeCar.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarRepository _repository;

        public CarController(CarRepository repository)
        {
            _repository = repository;
        }

        // GET: api/cars
        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetCars()
        {
            var cars = await _repository.GetCarsAsync();
            return Ok(cars);
        }

        // GET: api/cars/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _repository.GetCarByIdAsync(id);
            return car is not null ? Ok(car) : NotFound($"Car with ID {id} not found.");
        }

        // POST: api/cars
        [HttpPost]
        public async Task<ActionResult> CreateCar([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest("Car object cannot be null.");
            }

            // You can also add checks here to prevent creating duplicate cars based on some logic (e.g., Make, Model).
            await _repository.CreateCarAsync(car);

            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        // PUT: api/cars/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(int id, [FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest("Car object cannot be null.");
            }

            var existingCar = await _repository.GetCarByIdAsync(id);
            if (existingCar == null)
            {
                return NotFound($"Car with ID {id} not found.");
            }

            await _repository.UpdateCarAsync(id, car);
            return NoContent();
        }

        // DELETE: api/cars/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var existingCar = await _repository.GetCarByIdAsync(id);
            if (existingCar == null)
            {
                return NotFound($"Car with ID {id} not found.");
            }

            await _repository.DeleteCarAsync(id);
            return NoContent();
        }
    }
}