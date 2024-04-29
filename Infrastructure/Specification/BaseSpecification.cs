using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        protected void AddInclude(Expression<Func<T, object>> include)
        {
            base.Includes.Add(include);
        }
        
        protected void AddCriteria(Expression<Func<T, bool>> criteria)
        {
            base.Criteria = criteria;
        }
    }
}
