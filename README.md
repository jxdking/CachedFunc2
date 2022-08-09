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
```CachedFuncSvc.Create()``` accepts ```MemoryCacheEntryOptions``` argument. In the backend, it creates a MemoryCache entry with all the arguments at the time the ```CachedFunc<>``` is called. On the following calls to the  ```CachedFunc<>```, the cached value will be returned as long as the cache is not expired based on the ```MemoryCacheEntryOptions```.

For the entry with ```MemoryCacheEntryOptions.Property.NeverRemove```, the Cache will be eager loaded as soon as the current cache entry is expired.
