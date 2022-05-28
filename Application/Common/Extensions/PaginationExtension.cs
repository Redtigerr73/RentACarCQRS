using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Extensions
{
    public static class PaginationExtension
    {
        public static Task<Pagination<TDestination>> PaginationAsync<TDestination>(this IQueryable<TDestination> source, int pageNumber, int pageSize)
        {
            return Pagination<TDestination>.CreateAsync(source, pageNumber, pageSize);
        }
    }
}
