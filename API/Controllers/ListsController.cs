using Core.Specification;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using List = Core.Model.List;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsController : ControllerBase
    { 
        public IGenericRepository<List> _repo { get; }

        public ListsController(IGenericRepository<List> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IReadOnlyList<List>> Get()
        {
            ListsWithTasksSpecification listsWithTasksSpecification = new ListsWithTasksSpecification();
            return await _repo.ListAsync(listsWithTasksSpecification);
        }

        [HttpPost]
        public async Task<List> AddTask(List item) {

            return await _repo.Add(item);
        }

        [HttpPut]
        public IActionResult UpdateTask(List item)
        {
            Task<List> updateItem = _repo.Update(item);

            if (updateItem.Result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<List> GetById(int id)
        {
            ListsWithTasksSpecification listsWithTasksSpecification = new();
            listsWithTasksSpecification.AddCriteria(id);

            var item = await _repo.GetEnityWithSpec(listsWithTasksSpecification);
            return item;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(List item)
        {
            await _repo.Delete(item);
            return Ok();
        }
    }
}
