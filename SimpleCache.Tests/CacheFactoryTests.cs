using System;
using Xunit;

namespace SimpleCache.Tests
{
    public class CacheFactoryTests
    {
        [Fact]
        public void Create_Success()
        {
            CacheFactory facotry = new CacheFactory();
            var cache = facotry.Create<int>(new CacheConfigurationOptions());
            Assert.NotNull(cache);
        }

        [Fact]
        public void Create_NullOptions()
        {
            CacheFactory facotry = new CacheFactory();
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                facotry.Create<int>(null);
            });
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void CreateThenLocate_Success()
        {
            CacheFactory factory = new CacheFactory();
            var options = new CacheConfigurationOptions();
            options.CacheName = "TESTCACHE";
            var cache = factory.Create<int>(options);
            var secondCache = factory.Create<int>(options);

            Assert.Equal("TESTCACHE", secondCache.Name);
            Assert.Equal(cache, secondCache);
        }
    }
}
