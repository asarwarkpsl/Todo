using API.DTO;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public IGenericRepository<List> _repo { get; }

        public ListsController(IGenericRepository<List> repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IReadOnlyList<ListToReturn>> Get()
        {
            ListsWithTasksSpecification listsWithTasksSpecification = new ListsWithTasksSpecification();
            var items = await _repo.ListAsync(listsWithTasksSpecification);

            return _mapper.Map<IReadOnlyList<ListToReturn>>(items);
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
        public async Task<ListToReturn> GetById(int id)
        {
            ListsWithTasksSpecification listsWithTasksSpecification = new();
            listsWithTasksSpecification.AddCriteria(id);

            var item = await _repo.GetEnityWithSpec(listsWithTasksSpecification);

            return _mapper.Map<ListToReturn>(item);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTask(List item)
        {
            await _repo.Delete(item);
            return Ok();
        }
    }
}
