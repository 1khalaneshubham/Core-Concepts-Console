using System.Text.Json;
using CoreConceptsSuite.Models;

namespace CoreConceptsSuite.Services;

public class JsonStorage
{
    private readonly string _filePath = "employees.json";

    // Serialization - Save to JSON file
    public async Task SaveEmployeesAsync(List<Employee> employees)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(employees, options);
        await File.WriteAllTextAsync(_filePath, jsonString);
        Console.WriteLine($"✓ Saved {employees.Count} employees to {_filePath}");
    }

    // Deserialization - Load from JSON file
    public async Task<List<Employee>> LoadEmployeesAsync()
    {
        if (!File.Exists(_filePath))
        {
            Console.WriteLine("No saved file found. Returning empty list.");
            return [];
        }

        var jsonString = await File.ReadAllTextAsync(_filePath);
        var employees = JsonSerializer.Deserialize<List<Employee>>(jsonString);
        Console.WriteLine($"✓ Loaded {employees?.Count ?? 0} employees from {_filePath}");
        return employees ?? [];
    }
}