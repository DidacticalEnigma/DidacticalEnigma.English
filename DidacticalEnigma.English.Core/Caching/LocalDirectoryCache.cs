#nullable enable
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DidacticalEnigma.English.Core.Caching;

public class LocalDirectoryCache : ICache<string, string>
{
    private string _documentStorageDirectoryPath;

    public LocalDirectoryCache(string documentStorageDirectoryPath)
    {
        _documentStorageDirectoryPath = documentStorageDirectoryPath;
    }

    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }

    private string CreatePath(string key)
    {
        using var hasher = SHA1.Create();
        var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(key));
        var id = BitConverter.ToString(hash).Replace("-", "");
        var filename = id + ".html";
        var path = Path.Combine(_documentStorageDirectoryPath, filename);
        return path;
    }

    public async Task<string?> Get(string key)
    {
        try
        {
            var path = CreatePath(key);
            return await File.ReadAllTextAsync(path);
        }
        catch (FileNotFoundException)
        {
            return null;
        }
    }

    public async Task Set(string key, string value)
    {
        var path = CreatePath(key);
        await File.WriteAllTextAsync(path, value);
    }

    public async Task Clear()
    {
        // TODO
    }

    public Task ForceSave()
    {
        return Task.CompletedTask;
    }
}