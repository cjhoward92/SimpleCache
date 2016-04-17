using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCache
{
    public class CacheEntry
    {
        private object _key;
        private object _value;

        public CacheEntry(object key, object value)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            _key = key;
            _value = value;
        }

        public object Key
        {
            get
            {
                return _key;
            }
        }
        public object Value
        {
            get
            {
                return _value;
            }
        }

        public override string ToString()
        {
            return _key.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            return GetHashCode().Equals(obj.GetHashCode());
        }
        public override int GetHashCode()
        {
            return _key.GetHashCode();
        }
    }
}
