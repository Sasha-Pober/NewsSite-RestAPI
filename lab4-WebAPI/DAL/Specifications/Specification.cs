using DAL.Entities;
using System.Linq.Expressions;

namespace DAL.Specifications;

public abstract class Specification<T>(Expression<Func<T, bool>> criteria) where T : BaseEntity
{
    public Expression<Func<T, bool>>? Criteria { get; } = criteria;
    public List<Expression<Func<T, object>>> IncludeExpressions { get; } = [];
    public Expression<Func<T, object>>? OrderByExpression { get; private set; }
    public Expression<Func<T, object>>? OrderByDescendingExpression { get; private set; }
    public bool IsSplitQuery { get; protected set; }

    protected void AddInclude(Expression<Func<T, object>> includeExpression) => 
        IncludeExpressions.Add(includeExpression);

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression) => 
        OrderByExpression = orderByExpression;

    protected void AddOrderDescendingBy(Expression<Func<T, object>> orderByDescendingExpression) =>
        OrderByDescendingExpression = orderByDescendingExpression;

}
