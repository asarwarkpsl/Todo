
using Core.Model;

namespace Core.Specification
{
    public class ListsWithTasksSpecification:BaseSpecification<List>
    {
        public ListsWithTasksSpecification()
        {
            AddInclude(x => x.Tasks);
        }

        public void AddCriteria(int id)
        {
            AddCriteria(x => x.id == id);
        }
    }
}
