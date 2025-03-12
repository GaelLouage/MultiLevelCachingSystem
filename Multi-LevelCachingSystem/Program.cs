using System.Runtime.Caching;

internal class Program
{
    private static void Main(string[] args)
    {
        var number = 1;
        var text = "test";
        var cacheManager = new CacheManager();  
        cacheManager.Set<int>("number",number, 10);
        cacheManager.Set<string>("test", text, 20);
        do
        {
            var dataNumber = cacheManager.Get<int>("number");
            var dataText = cacheManager.Get<string>("test");
          
            Console.WriteLine(dataNumber);
            Console.WriteLine(".....");
            Console.WriteLine(dataText);
            Thread.Sleep(1000);
            Console.Clear();
        }while (true);
    }
}
public class CacheManager
{
    public Dictionary<string, MemoryCache?> InMemoryCache { get; set; } = new Dictionary<string, MemoryCache?>();

    public T Get<T>(string key)
    {
        if (InMemoryCache.ContainsKey(key))
        {
            var cache = InMemoryCache[key];
            // Retrieve data from the cache
            if (cache.Contains(key))
            {
                return (T)cache.Get(key);
            }
        }
        return default(T);

    }

    public void Set<T>(string key, T data, double timeSpan)
    {
        if (InMemoryCache.ContainsKey(key))
        {
            return;
        }
        // Create a MemoryCache instance
        var cache = MemoryCache.Default;


        // Add data to the cache with an expiration time of 5 minutes
        CacheItemPolicy cachePolicy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(timeSpan)
        };

        cache.Add(key, data, cachePolicy);
   
        InMemoryCache.Add(key,cache);
    }
}