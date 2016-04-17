using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCache
{
    public class Cache<TKey> : ICache<TKey>
    {
        private readonly IDictionary<TKey, object> _set;
        private readonly int _maxItems;

        public Cache(int maxItems)
        {
            _maxItems = maxItems;
            _set = new Dictionary<TKey, object>();
        }

        public object this[TKey key]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int NumberOfElements
        {
            get
            {
                return _set.Count;
            }
        }

        public void Add(CacheEntry entry)
        {
            if (NumberOfElements == _maxItems)
                throw new InvalidOperationException();

            throw new NotImplementedException();
        }

        public void Expire()
        {
            throw new NotImplementedException();
        }

        public void Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public void Remove(CacheEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
