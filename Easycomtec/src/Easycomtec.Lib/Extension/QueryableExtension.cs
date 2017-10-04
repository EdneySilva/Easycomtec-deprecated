using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Easycomtec.Lib.Extension
{
    public static class QueryableExtension
    {
        public static IQueryable<T> Property<T, TP>(this IQueryable<T> query, Expression<Func<T, TP>> property)
            where  T : class
        {
            return (query).Include(property);
        }
    }
}
