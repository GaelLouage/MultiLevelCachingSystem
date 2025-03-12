In-Memory Cache Manager

This project demonstrates how to implement a simple in-memory caching system using MemoryCache in C#. The CacheManager class allows you to store and retrieve data with an expiration time, providing basic cache functionality.
Features

    Cache Data: Store any type of data in memory.
    Expiration: Set expiration times for cached data.
    Retrieve Data: Retrieve cached data based on a key.
    Automatic Cache Clear: Cached data will expire after the set time interval.

Requirements

    .NET Core 5.0 or later
    Visual Studio or any IDE supporting C# development

Usage
Setup

    Clone or download the repository.
    Open the project in your preferred IDE (e.g., Visual Studio).
    Build and run the project.

git clone https://github.com/yourusername/in-memory-cache-manager.git
cd in-memory-cache-manager
dotnet build
dotnet run

Code Explanation

    Main Program
        It demonstrates how to store and retrieve data using the CacheManager.
        The cache is populated with an integer (1) and a string ("test").
        The program continuously retrieves and prints the values from the cache until it is stopped.

    CacheManager Class
        The CacheManager class manages a dictionary of caches (InMemoryCache) where the key is a string, and the value is a MemoryCache.
        The Set method adds a new item to the cache with an expiration time.
        The Get method retrieves the cached item by key.

Example of Use

var cacheManager = new CacheManager();

// Set data in the cache
cacheManager.Set<int>("number", 1, 10);
cacheManager.Set<string>("test", "Hello World!", 20);

// Retrieve data from the cache
var number = cacheManager.Get<int>("number");
var text = cacheManager.Get<string>("test");

Console.WriteLine(number); // Output: 1
Console.WriteLine(text);   // Output: Hello World!

Key Methods

    Set<T>(string key, T data, double timeSpan):
        Adds a new item to the cache with the specified expiration time (in seconds).
    Get<T>(string key):
        Retrieves an item from the cache by its key.

Performance Considerations

    The current implementation is a basic in-memory cache without advanced features such as thread-safety or cache eviction policies. Consider using MemoryCache.Default for more robust use cases or improving this system for concurrency handling.
