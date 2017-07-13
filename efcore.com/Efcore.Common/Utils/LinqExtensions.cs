using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Dynamic.Core;

public static class LinqExtensions
{

    public static IQueryable<T> DyOrderBy<T>(this IQueryable<T> query, string ordering, params object[] values)
    {
        return !string.IsNullOrEmpty(ordering) ? DynamicQueryableExtensions.OrderBy(query, ordering, values) : query;
    }

}
