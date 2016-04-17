using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCache
{
    public class CacheFactory
    {
        public ICache Create(CacheConfigurationOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return new Cache();
        }
    }
}
