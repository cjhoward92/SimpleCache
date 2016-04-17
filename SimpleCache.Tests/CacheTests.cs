using System;
using Xunit;

namespace SimpleCache.Tests
{
    public class CacheTests
    {
        [Fact]
        public void Add_Success()
        {
            var cache = new Cache<int>(10);
            int key = 1;
            string value = "derp";
            CacheEntry entry = new CacheEntry(key, value);
            cache.Add(entry);
            Assert.True(cache.NumberOfElements == 1);
        }
    }
}
