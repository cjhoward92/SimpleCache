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
            var cache = facotry.Create(new CacheConfigurationOptions());
            Assert.NotNull(cache);
        }

        [Fact]
        public void Create_NullOptions()
        {
            CacheFactory facotry = new CacheFactory();
            var ex = Assert.Throws<ArgumentNullException>(() =>
            {
                facotry.Create(null);
            });
            Assert.IsType<ArgumentNullException>(ex);
        }
    }
}
