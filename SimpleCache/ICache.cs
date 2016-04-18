using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCache
{
    public interface ICache<TKey>
    {
        int NumberOfElements { get; }
        string Name { get; }
        void Add(CacheEntry entry);
        void Remove(CacheEntry entry);
        void Remove(TKey key);
        void Expire();
        object this[TKey key] { get; set; }
    }
}
