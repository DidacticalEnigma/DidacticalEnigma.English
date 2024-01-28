using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DidacticalEnigma.English.Core.Caching;

#nullable enable

public class JsonFileCache : ICache<string, IReadOnlyList<string>>, IDisposable, IAsyncDisposable
{
    private readonly string _filePath;
    private Dictionary<string, IReadOnlyList<string>> _dataImpl;
    private IDictionary<string, IReadOnlyList<string>> Data => _dataImpl;

    private JsonFileCache(string path)
    {
        _filePath = path;
        _dataImpl = new Dictionary<string, IReadOnlyList<string>>();
    }

    public static JsonFileCache Create(string path)
    {
        var c = new JsonFileCache(path);
        c.Load();
        return c;
    }
    
    public static async Task<JsonFileCache> CreateAsync(string path)
    {
        var c = new JsonFileCache(path);
        await c.LoadAsync();
        return c;
    }

    public void Load()
    {
        try
        {
            _dataImpl = JsonSerializer.Deserialize<Dictionary<string, IReadOnlyList<string>>>(
                File.ReadAllText(_filePath)) ?? throw new InvalidDataException();
        }
        catch (FileNotFoundException)
        {
            // do nothing
        }
    }
    
    public async Task LoadAsync()
    {
        try
        {
            _dataImpl = JsonSerializer.Deserialize<Dictionary<string, IReadOnlyList<string>>>(
                await File.ReadAllTextAsync(_filePath)) ?? throw new InvalidDataException();
        }
        catch (FileNotFoundException)
        {
            // do nothing
        }
    }

    public void Save()
    {
        File.WriteAllText(_filePath, JsonSerializer.Serialize(_dataImpl));
    }

    public async Task SaveAsync()
    {
        await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(_dataImpl));
    }

    public void Dispose()
    {
        Save();
    }
    
    public async ValueTask DisposeAsync()
    {
        await SaveAsync();
    }

    public Task<IReadOnlyList<string>?> Get(string key)
    {
        return Task.FromResult(_dataImpl.GetValueOrDefault(key));
    }

    public Task Set(string key, IReadOnlyList<string> value)
    {
        _dataImpl[key] = value;
        return Task.CompletedTask;
    }

    public async Task Clear()
    {
        _dataImpl = new Dictionary<string, IReadOnlyList<string>>();
        await ForceSave();
    }

    public async Task ForceSave()
    {
        await SaveAsync();
    }
}