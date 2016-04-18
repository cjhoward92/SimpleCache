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
        private readonly string _name;

        public Cache(int maxItems, string name)
        {
            _maxItems = maxItems;
            _name = name;
            _set = new Dictionary<TKey, object>();
        }

        public object this[TKey key]
        {
            get
            {
                if (!_set.ContainsKey(key))
                    throw new InvalidOperationException();

                return _set[key];
            }

            set
            {
                if (!_set.ContainsKey(key))
                    throw new InvalidOperationException();

                _set[key] = value;
            }
        }

        public int NumberOfElements
        {
            get
            {
                return _set.Count;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public void Add(CacheEntry entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));
            if (NumberOfElements == _maxItems)
                throw new InvalidOperationException("No more items allowed in this cache!");

            //TODO add generated expressions for key-type comparison (To avoid conversion errors)
            if (_set.ContainsKey((TKey)entry.Key)) return;
            _set.Add((TKey)entry.Key, entry.Value);
        }

        public void Expire()
        {
            _set.Clear();
        }

        public void Remove(TKey key)
        {
            if (_set.Count == 0) return;
            if (!_set.ContainsKey(key)) return;
            _set.Remove(key);
        }

        public void Remove(CacheEntry entry)
        {
            Remove((TKey)entry.Key);
        }
    }
}
