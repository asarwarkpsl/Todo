using System.Linq;
using System.Linq.Expressions;


namespace Core.Specification
{
    public abstract class ISpecification<T>
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T,Object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
    }
}
