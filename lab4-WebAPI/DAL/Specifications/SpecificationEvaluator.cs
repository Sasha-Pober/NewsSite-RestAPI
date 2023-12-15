using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Specifications;

public static class SpecificationEvaluator
{
    public static IQueryable<T> GetQuery<T>(IQueryable<T> inputQuery, Specification<T> specification) where T : BaseEntity
    {
        IQueryable<T> queryable = inputQuery;

        if(specification.Criteria is not null)
        {
            queryable = queryable.Where(specification.Criteria);
        }

        queryable = specification.IncludeExpressions.Aggregate(queryable,
            (current, includeExpression) => current.Include(includeExpression));

        if(specification.OrderByExpression is not null)
        {
            queryable = queryable.OrderBy(specification.OrderByExpression);
        }
        else if(specification.OrderByDescendingExpression is not null) 
        {
            queryable = queryable.OrderByDescending(specification.OrderByDescendingExpression);
        }

        if(specification.IsSplitQuery)
        {
            queryable = queryable.AsSplitQuery();
        }

        return queryable;
    }
}
