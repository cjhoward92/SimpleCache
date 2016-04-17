using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCache
{
    public class CacheConfigurationOptions
    {
        private const int _DEFAULT_MAX_ITEMS = 10;

        public CacheConfigurationOptions()
        {
            this.MaxNumberOfItems = _DEFAULT_MAX_ITEMS;
        }

        public int MaxNumberOfItems { get; set; }
    }
}
