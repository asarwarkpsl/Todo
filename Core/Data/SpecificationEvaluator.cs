using Core.Model;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseModel    {

        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecification<TEntity> spec) 
        {
            var query = inputQuery.AsQueryable();

            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if(spec.Includes.Count > 0)
            {
                query = spec.Includes.Aggregate(query,(current,include) => current.Include (include));
            }

            return query;
        }

    }
}
