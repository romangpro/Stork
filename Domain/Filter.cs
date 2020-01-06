using System;
using System.Linq.Expressions;
using System.Linq;

namespace Domain
{
    // specification pattern
    public abstract class Filter<T>
    {
        public abstract Expression<Func<T, bool>> Expression();
        private Lazy<Func<T, bool>> _predicate => new Lazy<Func<T, bool>>(() => Expression().Compile());

        public bool Is(T entity)
        {
            return _predicate.Value(entity);
        }

        public Filter<T> And(Filter<T> filter)
        {
            return new And<T>(this, filter);
        }

        public Filter<T> Or(Filter<T> filter)
        {
            return new Or<T>(this, filter);
        }
    }

    public class And<T> : Filter<T>
    {
        private readonly Filter<T> _left;
        private readonly Filter<T> _right;

        public And(Filter<T> left, Filter<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> Expression()
        {
            Expression<Func<T, bool>> leftExpression = _left.Expression();
            Expression<Func<T, bool>> rightExpression = _right.Expression();

            BinaryExpression andExpression = System.Linq.Expressions.Expression.AndAlso(
                leftExpression.Body, rightExpression.Body);

            return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(
                andExpression, leftExpression.Parameters.Single());
        }
    }

    public class Or<T> : Filter<T>
    {
        private readonly Filter<T> _left;
        private readonly Filter<T> _right;

        public Or(Filter<T> left, Filter<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> Expression()
        {
            Expression<Func<T, bool>> leftExpression = _left.Expression();
            Expression<Func<T, bool>> rightExpression = _right.Expression();

            BinaryExpression andExpression = System.Linq.Expressions.Expression.OrElse(
                leftExpression.Body, rightExpression.Body);

            return System.Linq.Expressions.Expression.Lambda<Func<T, bool>>(
                andExpression, leftExpression.Parameters.Single());
        }
    }
}
