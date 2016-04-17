using System;
using Xunit;

namespace SimpleCache.Tests
{
    public class CacheTests
    {
        [Fact]
        public void Cache_Success()
        {
            Cache cache = new Cache();
            int key = 1;
            string value = "derp";
            CacheEntry entry = new CacheEntry(key, value);
            cache.Cache(entry);
            Assert.True(cache.NumberOfElements == 1);
        }
    }
}
