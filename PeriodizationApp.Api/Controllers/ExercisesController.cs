using Microsoft.AspNetCore.Mvc;
using PeriodizationApp.Core.Entities;
using PeriodizationApp.Core.Interfaces;

namespace PeriodizationApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExercisesController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exercises = await _exerciseRepository.GetAllAsync();
            return Ok(exercises);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise(Exercise exercise)
        {
            var newExercise = await _exerciseRepository.AddAsync(exercise);
            return Ok(newExercise);
        }
    }
}
