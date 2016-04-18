using System;
using Xunit;

namespace SimpleCache.Tests
{
    public class CacheTests
    {
        private const string _DEFAULT_NAME = "Default";

        [Fact]
        public void Add_Success()
        {
            var cache = new Cache<int>(10, _DEFAULT_NAME);
            int key = 1;
            string value = "derp";
            CacheEntry entry = new CacheEntry(key, value);
            cache.Add(entry);
            Assert.True(cache.NumberOfElements == 1);
        }

        [Fact]
        public void AddMultiple_Success()
        {
            var cache = new Cache<int>(10, _DEFAULT_NAME);
            int key = 1;
            string value = "derp";
            CacheEntry entry = new CacheEntry(key, value);
            CacheEntry entry2 = new CacheEntry(2, value);
            CacheEntry entry3 = new CacheEntry(3, value);
            cache.Add(entry);
            cache.Add(entry2);
            cache.Add(entry3);
            Assert.True(cache.NumberOfElements == 3);
        }

        [Fact]
        public void Expire_Success()
        {
            var cache = new Cache<int>(10, _DEFAULT_NAME);
            int key = 1;
            string value = "derp";
            CacheEntry entry = new CacheEntry(key, value);
            CacheEntry entry2 = new CacheEntry(2, value);
            CacheEntry entry3 = new CacheEntry(3, value);
            cache.Add(entry);
            cache.Add(entry2);
            cache.Add(entry3);
            cache.Expire();
            Assert.True(cache.NumberOfElements == 0);
        }

        [Fact]
        public void MaxItems_Exception()
        {
            var cache = new Cache<int>(2, _DEFAULT_NAME);
            int key = 1;
            string value = "derp";
            CacheEntry entry = new CacheEntry(key, value);
            CacheEntry entry2 = new CacheEntry(2, value);
            CacheEntry entry3 = new CacheEntry(3, value);
            cache.Add(entry);
            cache.Add(entry2);
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                cache.Add(entry3);
            });

            Assert.IsType<InvalidOperationException>(ex);
        }

        [Fact]
        public void Add_NullEntry()
        {
            var cache = new Cache<int>(2, _DEFAULT_NAME);

            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                cache.Add(null);
            });

            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void Remove_Success()
        {
            var cache = new Cache<int>(10, _DEFAULT_NAME);
            int key = 1;
            string value = "derp";
            CacheEntry entry = new CacheEntry(key, value);
            cache.Add(entry);
            cache.Remove(key);
            Assert.True(cache.NumberOfElements == 0);
        }

        [Fact]
        public void RemoveEntry_Success()
        {
            var cache = new Cache<int>(10, _DEFAULT_NAME);
            int key = 1;
            string value = "derp";
            CacheEntry entry = new CacheEntry(key, value);
            cache.Add(entry);
            cache.Remove(entry);
            Assert.True(cache.NumberOfElements == 0);
        }
    }
}
