using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCache
{
    public class CacheFactory
    {
        private readonly IDictionary<string, object> _activeCaches;

        public CacheFactory()
        {
            _activeCaches = new Dictionary<string, object>();
        }

        /// <summary>
        /// Creates or restores a specific cache.
        /// </summary>
        /// <typeparam name="TKey">The type of key used by the cache when doing index lookups</typeparam>
        /// <param name="options">The specific construction options for the cache</param>
        /// <returns>A valid cache instance</returns>
        public ICache<TKey> Create<TKey>(CacheConfigurationOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            if (String.IsNullOrWhiteSpace(options.CacheName))
                throw new NullReferenceException();

            var cache = Locate<TKey>(options.CacheName);
            if(cache == null)
            {
                cache = new Cache<TKey>(options.MaxNumberOfItems, options.CacheName);
                _activeCaches.Add(cache.Name, cache);
            }

            return cache;
        }

        private ICache<TKey> Locate<TKey>(string cacheName)
        {
            //TODO make this routine more efficient. It's pretty garbo ATM (IL, maybe, or Expressions)

            if (_activeCaches.Count == 0) return null;
            if (!_activeCaches.ContainsKey(cacheName)) return null;

            var cache = _activeCaches[cacheName];
            if (cache.GetType().IsAssignableFrom(typeof(ICache<>).MakeGenericType(typeof(TKey))))
                throw new Exception("Wat");

            return cache as ICache<TKey>;
        }
    }
}
