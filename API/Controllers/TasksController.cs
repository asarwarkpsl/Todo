using API.DTO;
using AutoMapper;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Task = Core.Model.Task;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMapper _mapper;

        public IGenericRepository<Task> _repo { get; }

        public TasksController(IGenericRepository<Task> repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<TaskToReturn>> Get()
        {
            var item = await _repo.GetAll();

            return _mapper.Map<IList<TaskToReturn>>(item);
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
        public async Task<TaskToReturn> GetById(int id)
        {
            var item = await _repo.Get(id);

            return _mapper.Map<TaskToReturn>(item);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(Task item)
        {
            await _repo.Delete(item);
            return Ok();
        }
    }
}
