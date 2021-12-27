using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PagedListExtensions
{
    public static class PagedListExtensions
    {
        /// <summary>
        /// Returns an <see cref="PagedList{TResult}" /> from an <see cref="IQueryable{T}" /> by enumerating it.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         See <see href="https://bit.ly/3ruY8nn"> link</see> for more information and examples.
        ///     </para>
        /// </remarks>
        /// <returns> An <see cref="PagedList{TResult}"/> whose elements are the result of invoking a projection function on each element of source.</returns>
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
        /// <summary>
        /// Returns an <see cref="PagedList{TResult}" /> from an <see cref="IQueryable{T}" /> by enumerating it.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         See <see href="https://bit.ly/3ruY8nn"> link</see> for more information and examples.
        ///     </para>
        /// </remarks>
        /// <returns> An <see cref="PagedList{TResult}"/> whose elements are the result of invoking a projection function on each element of source.</returns>
        public static PagedList<TResult> ToPagedList<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, int, TResult>> selector, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(selector).ToList();

            return new PagedList<TResult>(items, count, pageNumber, pageSize);
        }
        /// <summary>
        /// Asynchronously returns an <see cref="List{TResult}" /> from an <see cref="IQueryable{T}" /> by enumerating it  asynchronously.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Multiple active operations on the same context instance are not supported. Use <see langword="await" /> to ensure
        ///         that any asynchronous operations have completed before calling another method on this context.
        ///          See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see> for more information and examples.
        ///     </para>
        ///     <para>
        ///         See <see href="https://bit.ly/3ruY8nn"> link</see> for more information and examples.
        ///     </para>
        /// </remarks>
        /// <returns> An <see cref="List{TResult}"/> whose elements are the result of invoking a projection function on each element of source.</returns>
        public static async Task<List<TResult>> ToPagedListAsync<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, int, TResult>> selector, int pageNumber, int pageSize)
        => await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(selector).ToListAsync();
        /// <summary>
        /// Asynchronously returns an <see cref="PagedList{TSource}" /> from an <see cref="IQueryable{T}" /> by enumerating it  asynchronously.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Multiple active operations on the same context instance are not supported. Use <see langword="await" /> to ensure
        ///         that any asynchronous operations have completed before calling another method on this context.
        ///          See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see> for more information and examples.
        ///     </para>
        ///     <para>
        ///         See <see href="https://bit.ly/3ruY8nn"> link</see> for more information and examples.
        ///     </para>
        /// </remarks>
        /// <returns> An <see cref="PagedList{TSource}"/> whose elements are the result of invoking a projection function on each element of source.</returns>
        public static async Task<PagedList<TSource>> ToPagedListAsync<TSource>(this IQueryable<TSource> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedList<TSource>(items, count, pageNumber, pageSize);
        }
        /// <summary>
        /// Asynchronously returns an <see cref="PagedList{TResult}" /> from an <see cref="IQueryable{T}" /> by enumerating it  asynchronously.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Multiple active operations on the same context instance are not supported. Use <see langword="await" /> to ensure
        ///         that any asynchronous operations have completed before calling another method on this context.
        ///          See <see href="https://aka.ms/efcore-docs-threading">Avoiding DbContext threading issues</see> for more information and examples.
        ///     </para>
        ///     <para>
        ///         See <see href="https://bit.ly/3ruY8nn"> link</see> for more information and examples.
        ///     </para>
        /// </remarks>
        /// <returns> An <see cref="PagedList{TResult}"/> whose elements are the result of invoking a projection function on each element of source.</returns>
        public static async Task<PagedList<TResult>> ToPagedListAsync<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(selector).ToListAsync();

            return new PagedList<TResult>(items, count, pageNumber, pageSize);
        }
    }
}
