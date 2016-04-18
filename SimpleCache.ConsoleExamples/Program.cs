using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCache.ConsoleExamples
{
    class Program
    {
        public const string MY_FIRST_CACHE = "MyFirstCache";

        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            Console.WriteLine("Initializing Factory");

            CacheFactory factory = new CacheFactory();

            Console.WriteLine("Configuring Options...");
            CacheConfigurationOptions options = new CacheConfigurationOptions()
            {
                MaxNumberOfItems = 10,
                CacheName = MY_FIRST_CACHE
            };

            Console.WriteLine($"Generating Cache with name {MY_FIRST_CACHE}");
            ICache<int> cache = factory.Create<int>(options);

            Console.WriteLine("Generating Entries...");
            CacheEntry entry = new CacheEntry(1, "Test Value 1");
            var entry2 = new CacheEntry(2, "Test Value 2");

            Console.WriteLine("Adding Entries...");
            cache.Add(entry);
            cache.Add(entry2);

            Console.WriteLine($"First Entry: {cache[1].ToString()}");
            Console.WriteLine($"Second Entry: {cache[2].ToString()}");

            Console.WriteLine("Removing Cache Reference..");
            cache = null;
            cache = factory.Create<int>(options);

            Console.WriteLine($"First Entry, again: {cache[1].ToString()}");
            Console.WriteLine($"Second Entry, again: {cache[2].ToString()}");
            Console.ReadKey();
        }
    }
}
