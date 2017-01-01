using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swords.Util
{
    class Registry<T>
    {
        List<RegistryEntry<string, T>> entries;

        public Registry()
        {
            entries = new List<RegistryEntry<string, T>>();
        }

        public bool Add(string name, T value)
        {
            if (Contains(name, value))
            {
                return false;
            }
            entries.Add(new RegistryEntry<string, T>(name, value));
            return true;
        }

        public bool Remove(string name)
        {
            if (!Contains(name))
            {
                return false;
            }
            entries.Remove(Find(name));
            return true;
        }

        public bool Remove(T value)
        {
            if (!Contains(value))
            {
                return false;
            }
            entries.Remove(Find(value));
            return true;
        }

        public T Get(string name)
        {
            RegistryEntry<string, T> entry = Find(name);
            if (entry == null) {
                return default(T);
            }
            return entry.Value;
        }

        private RegistryEntry<string, T> Find(string name)
        {
            if (!Contains(name))
            {
                return null;
            }
            foreach (RegistryEntry<string, T> entry in entries)
            {
                if (entry.Key.Equals(name))
                {
                    return entry;
                }
            }
            return null;
        }

        private RegistryEntry<string, T> Find(T value)
        {
            if (!Contains(value))
            {
                return null;
            }
            foreach (RegistryEntry<string, T> entry in entries)
            {
                if (entry.Value.Equals(value))
                {
                    return entry;
                }
            }
            return null;
        }

        public bool Contains(string name)
        {
            foreach (RegistryEntry<string, T> entry in entries)
            {
                if (entry.Key.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(T value)
        {
            foreach (RegistryEntry<string, T> entry in entries)
            {
                if (entry.Value.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(string name, T Value)
        {
            return Contains(name) || Contains(Value);
        }
    }
}
