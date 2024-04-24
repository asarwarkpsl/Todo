using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Task = Core.Model.Task;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        public IGenericRepository<Task> _repo { get; }

        public TasksController(IGenericRepository<Task> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IList<Task>> Get()
        {
            return await _repo.GetAll();
        }

        [HttpPost]
        public async Task<Task> AddTask(Task item)
        {

            return await _repo.Add(item);
        }

        [HttpPut]
        public IActionResult UpdateTask(Task item)
        {
            Task<Task> updateItem = _repo.Update(item);

            if (updateItem.Result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<Task> GetById(int id)
        {
            var item = await _repo.Get(id);
            return item;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(Task item)
        {
            await _repo.Delete(item);
            return Ok();
        }
    }
}
