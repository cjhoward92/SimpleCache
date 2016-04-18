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
        private const string _DEFAULT_CACHE_NAME = "Default";

        public CacheConfigurationOptions()
        {
            this.MaxNumberOfItems = _DEFAULT_MAX_ITEMS;
            this.CacheName = _DEFAULT_CACHE_NAME;
        }

        public int MaxNumberOfItems { get; set; }
        public string CacheName { get; set; }
    }
}
