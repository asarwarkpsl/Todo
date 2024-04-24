using Core.Model;
using Task = System.Threading.Tasks.Task;

namespace Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        public Task<T> Add(T item);
        public Task Delete(T item);
        public Task<T?> Get(int index);
        public Task<IList<T>> GetAll();

        public Task<T?> Update(T item);
    }
}
