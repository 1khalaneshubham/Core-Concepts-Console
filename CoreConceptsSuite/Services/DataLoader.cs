using CoreConceptsSuite.Models;
using System.Diagnostics;

namespace CoreConceptsSuite.Services;

public class DataLoader
{
    // Async/Await demonstration - Simulate loading from multiple sources
    public async Task<List<string>> LoadFromSourcesAsync(params string[] sources)
    {
        var results = new List<string>();
        var tasks = sources.Select(LoadDataAsync);

        var loadedData = await Task.WhenAll(tasks);
        results.AddRange(loadedData);

        return results;
    }

    private async Task<string> LoadDataAsync(string source)
    {
        await Task.Delay(1000); // Simulate network/database delay
        return $"Data loaded from {source} at {DateTime.Now:T}";
    }

    // Simulate real async operations
    public async Task<List<Employee>> LoadEmployeesAsync()
    {
        Console.WriteLine("Starting async employee load...");
        var stopwatch = Stopwatch.StartNew();

        var task1 = SimulateApiCall("API 1");
        var task2 = SimulateApiCall("API 2");
        var task3 = SimulateApiCall("Database");

        var results = await Task.WhenAll(task1, task2, task3);

        stopwatch.Stop();
        Console.WriteLine($"All sources loaded in {stopwatch.ElapsedMilliseconds}ms (non-blocking!)");

        return results.SelectMany(r => r).ToList();
    }

    private async Task<List<Employee>> SimulateApiCall(string source)
    {
        await Task.Delay(800); // Simulate network call
        return
        [
            new Employee { Id = new Random().Next(100, 999), Name = $"{source} User 1", Department = source, Salary = 50000 },
            new Employee { Id = new Random().Next(100, 999), Name = $"{source} User 2", Department = source, Salary = 60000 }
        ];
    }
}