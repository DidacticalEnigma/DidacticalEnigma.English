using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using TinyIndex;

namespace DidacticalEnigma.English.Core;

public class SimpleJsonCache : IDictionary<string, IReadOnlyList<string>>, IDisposable, IAsyncDisposable
{
    private string filePath;
    private Dictionary<string, IReadOnlyList<string>> DataImpl;
    private IDictionary<string, IReadOnlyList<string>> Data => DataImpl;

    public SimpleJsonCache(string path)
    {
        filePath = path;
        DataImpl = new Dictionary<string, IReadOnlyList<string>>();
    }

    public void Load()
    {
        DataImpl = JsonSerializer.Deserialize<Dictionary<string, IReadOnlyList<string>>>(
            File.ReadAllText(filePath));
    }
    
    public async Task LoadAsync()
    {
        DataImpl = JsonSerializer.Deserialize<Dictionary<string, IReadOnlyList<string>>>(
            await File.ReadAllTextAsync(filePath));
    }

    public void Save()
    {
        File.WriteAllText(filePath, JsonSerializer.Serialize(DataImpl));
    }

    public async Task SaveAsync()
    {
        await File.WriteAllTextAsync(filePath, JsonSerializer.Serialize(DataImpl));
    }

    public void Dispose()
    {
        Save();
    }


    public IEnumerator<KeyValuePair<string, IReadOnlyList<string>>> GetEnumerator()
    {
        return Data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)Data).GetEnumerator();
    }

    public void Add(KeyValuePair<string, IReadOnlyList<string>> item)
    {
        Data.Add(item);
    }

    public void Clear()
    {
        Data.Clear();
    }

    public bool Contains(KeyValuePair<string, IReadOnlyList<string>> item)
    {
        return Data.Contains(item);
    }

    public void CopyTo(KeyValuePair<string, IReadOnlyList<string>>[] array, int arrayIndex)
    {
        Data.CopyTo(array, arrayIndex);
    }

    public bool Remove(KeyValuePair<string, IReadOnlyList<string>> item)
    {
        return Data.Remove(item);
    }

    public int Count => Data.Count;

    public bool IsReadOnly => Data.IsReadOnly;

    public void Add(string key, IReadOnlyList<string> value)
    {
        Data.Add(key, value);
    }

    public bool ContainsKey(string key)
    {
        return Data.ContainsKey(key);
    }

    public bool Remove(string key)
    {
        return Data.Remove(key);
    }

    public bool TryGetValue(string key, out IReadOnlyList<string> value)
    {
        return Data.TryGetValue(key, out value);
    }

    public IReadOnlyList<string> this[string key]
    {
        get => Data[key];
        set => Data[key] = value;
    }

    public ICollection<string> Keys => Data.Keys;

    public ICollection<IReadOnlyList<string>> Values => Data.Values;
    
    public async ValueTask DisposeAsync()
    {
        await SaveAsync();
    }
}