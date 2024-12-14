
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace BuildingBlocks.Caching;

public class RedisCacheService(IDistributedCache? cache) : IRedisCacheService
{
    private readonly IDistributedCache? _cache = cache;

    public T? GetData<T>(string key)
    {
        var data = _cache?.GetString(key);

        if (data == null) return default;

        return JsonSerializer.Deserialize<T>(data);
    }

    public void SetData<T>(string key, T data)
    {
        var options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        _cache?.SetString(key, JsonSerializer.Serialize(data), options);
    }

    public void DeleteData(string key)
    {
        _cache?.Remove(key);
    }
}
