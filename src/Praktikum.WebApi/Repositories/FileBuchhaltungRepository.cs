using System.Text.Json;
using Praktikum.WebApi.Models;

namespace Praktikum.WebApi.Repositories;

public class FileBuchhaltungRepository : IBuchhaltungRepository
{
    private readonly string _filePath = "buchhaltung.json";
    private readonly object _lock = new();

    private List<Buchhaltungszeile> Load()
    {
        if (!File.Exists(_filePath)) return new List<Buchhaltungszeile>();

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Buchhaltungszeile>>(json) ?? new List<Buchhaltungszeile>();
    }

    private void Save(List<Buchhaltungszeile> zeilen)
    {
        var json = JsonSerializer.Serialize(zeilen, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    public IEnumerable<Buchhaltungszeile> GetAll()
    {
        lock (_lock)
        {
            return Load();
        }
    }

    public Buchhaltungszeile? GetById(int id)
    {
        lock (_lock)
        {
            return Load().FirstOrDefault(z => z.Id == id);
        }
    }

    public void Add(Buchhaltungszeile zeile)
    {
        lock (_lock)
        {
            var list = Load();
            list.Add(zeile);
            Save(list);
        }
    }

    public bool Update(int id, Buchhaltungszeile updated)
    {
        lock (_lock)
        {
            var list = Load();
            var index = list.FindIndex(z => z.Id == id);
            if (index == -1) return false;

            // Hier ersetzen wir das gesamte Objekt inkl. Locked
            list[index] = updated;

            Save(list);
            return true;
        }
    }

    public bool Delete(int id)
    {
        lock (_lock)
        {
            var list = Load();
            var existing = list.FirstOrDefault(z => z.Id == id);
            if (existing == null) return false;

            list.Remove(existing);
            Save(list);
            return true;
        }
    }

    public bool SetLock(int id, bool locked)
    {
        lock (_lock)
        {
            var list = Load();
            var existing = list.FirstOrDefault(z => z.Id == id);
            if (existing == null) return false;

            existing.Locked = locked;
            Save(list);
            return true;
        }
    }
}