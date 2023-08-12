using System.Net.NetworkInformation;

namespace LocationManager.Blazor.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Bir listenin dolu-boş kontrolü
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrNotAny<TEntity>(this ICollection<TEntity> source) => source is null || !source.Any();


    }
}
