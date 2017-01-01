using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swords.Util
{
    class RegistryEntry<TKey, TValue>
    {
        private TKey key;
        private TValue value;

        public TKey Key { get { return key; } }
        public TValue Value { get { return value; } }

        public RegistryEntry(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
