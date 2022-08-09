# CachedFunc2
This library is used to create a cached function. The return value of the function is cached with IMemoryCache.

## Register The Service
```c#
serviceCollection.AddMemoryCache();
serviceCollection.AddCachedFunc();
```
Then, you can get ```CachedFuncSvc``` object through dependency injection.

## How to Use
Assume there is a slow-running function.
```c#
static int SlowFunc(int n) {
    Thread.Sleep(1000);
    return n;
}
```

Create CachedFunc with [CachedFuncSvc] object.
```c#
CachedFunc<int, int> cachedFunc = cachedFuncSvc.Create(SlowFunc);
```

Then, you have a cached function. Call this function in the same way as the orignal function.
```c#
int result = cachedFunc(12345);
```

## Options
```CachedFuncSvc.Create()``` accepts ```MemoryCacheEntryOptions``` argument. In the backend, it creates a MemoryCache entry for every combination of all the arguments of the target function. Each entry will be added to MemoryCache with the same ```MemoryCacheEntryOptions``` provided.
For the entry with ```MemoryCacheEntryOptions.Property.NeverRemove```, the Cache will be eager loaded as soon as the current cache entry is expired.
