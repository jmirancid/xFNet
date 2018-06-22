using System;
using System.Linq.Expressions;

namespace xFNet.Common.Extensions
{
    public static class ExpressionExtensions
    {
        public static MemberExpression GetMemberExpression<TSource, TValue>(this Expression<Func<TSource, TValue>> expression)
            where TSource : class
        {
            if (expression == null)
            {
                return null;
            }

            if (expression.Body is MemberExpression)
            {
                return (MemberExpression)expression.Body;
            }

            if (expression.Body is UnaryExpression)
            {
                Expression operand = ((UnaryExpression)expression.Body).Operand;
                if (operand is MemberExpression)
                {
                    return (MemberExpression)operand;
                }

                if (operand is MethodCallExpression)
                {
                    return ((MethodCallExpression)operand).Object as MemberExpression;
                }
            }

            return null;
        }

        public static string GetNameFor<TSource, TValue>(this Expression<Func<TSource, TValue>> expression)
            where TSource : class
        {
            return new ExpressionNameVisitor().Visit(expression.Body);
        }

        public static TValue GetValueFrom<TSource, TValue>(this Expression<Func<TSource, TValue>> expression, TSource source)
            where TSource : class
        {
            try
            {
                return source == null ? default(TValue) : expression.Compile().Invoke(source);
            }
            catch (Exception)
            {
                return default(TValue);
            }
        }
    }

    public class ExpressionNameVisitor : ExpressionVisitor
    {
        public new string Visit(Expression expression)
        {
            if (expression is UnaryExpression)
            {
                expression = ((UnaryExpression)expression).Operand;
            }

            if (expression is MethodCallExpression)
            {
                return this.Visit((MethodCallExpression)expression);
            }

            if (expression is MemberExpression)
            {
                return this.Visit((MemberExpression)expression);
            }

            if (expression is BinaryExpression && expression.NodeType == ExpressionType.ArrayIndex)
            {
                return this.Visit((BinaryExpression)expression);
            }

            return null;
        }

        private string Visit(BinaryExpression expression)
        {
            string result = null;
            if (expression.Left is MemberExpression)
            {
                result = this.Visit((MemberExpression)expression.Left);
            }

            object index = Expression.Lambda(expression.Right).Compile().DynamicInvoke();
            return result + string.Format("[{0}]", index);
        }

        private string Visit(MemberExpression expression)
        {
            string name = expression.Member.Name;
            string ancestorName = Visit(expression.Expression);
            if (ancestorName != null)
            {
                name = ancestorName + "." + name;
            }

            return name;
        }

        private string Visit(MethodCallExpression expression)
        {
            string name = null;
            if (expression.Object is MemberExpression)
            {
                name = this.Visit((MemberExpression)expression.Object);
            }

            // TODO: Is there a more certain way to determine if this is an indexed property?
            if (expression.Method.Name == "get_Item" && expression.Arguments.Count == 1)
            {
                object index = Expression.Lambda(expression.Arguments[0]).Compile().DynamicInvoke();
                name += string.Format("[{0}]", index);
            }
            else
            {
                name = expression.Method.Name;
            }

            return name;
        }
    }
}
