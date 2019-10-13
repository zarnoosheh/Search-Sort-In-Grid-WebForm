using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace GridSimple
{
    public static class ExpressionManager
    {
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }
    }

    class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;

            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }

    public static class Sys
    {
        public static int ToInt(this object _str)
        {
            if (_str == null)
                _str = string.Empty;
            Int32 _Result = 0;
            Int32.TryParse(_str.ToString(), out _Result);
            return _Result;
        }
    }

    public class _URL
    {
        public static void Redirect(string QueryString, string Value, string RemoveQuery = "")
        {
            try
            {
                var _Query = HttpUtility.ParseQueryString(HttpContext.Current.Request.QueryString.ToString());
                _Query.Set(QueryString, Value);
                if (!string.IsNullOrWhiteSpace(RemoveQuery))
                    _Query.Remove(RemoveQuery);

                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath + "?" + _Query);
            }
            catch (Exception ex)
            {
            }
        }
    }
}