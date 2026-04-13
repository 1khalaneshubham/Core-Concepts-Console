using CoreConceptsSuite.Models;
using CoreConceptsSuite.Services;
using System.Runtime.CompilerServices;
using System.Runtime.CompilerServices;
namespace CoreConceptsSuite;
class Program
{
    // ... rest of the code
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== C# Core Concepts Suite ===\n");

        // Demo 1: Async/Await - Non-blocking data loading
        await DemoAsyncAwait();

        // Demo 2: LINQ - Data querying and manipulation
        await DemoLINQ();

        // Demo 3: File Serialization - JSON save/load
        await DemoFileSerialization();

        // Demo 4: C# 14 Features - Inline arrays and params collections
        DemoCSharp14Features();

        Console.WriteLine("\n=== All Demos Completed! ===");
    }

    // 1. ASYNC/AWAIT DEMO
    static async Task DemoAsyncAwait()
    {
        Console.WriteLine("📡 ASYNC/AWAIT DEMO - Non-blocking operations\n");

        var dataLoader = new DataLoader();

        Console.WriteLine("Loading employees from multiple sources asynchronously...");
        Console.WriteLine("(Main thread can do other work while loading)\n");

        // Non-blocking operation
        var loadingTask = dataLoader.LoadEmployeesAsync();

        // Simulate other work while data loads
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"Main thread doing other work... ({i}/3)");
            await Task.Delay(200);
        }

        var employees = await loadingTask;

        Console.WriteLine($"\n✓ Loaded {employees.Count} employees asynchronously:");
        foreach (var emp in employees.Take(3))
            Console.WriteLine($"  {emp}");

        Console.WriteLine("\n" + new string('-', 50) + "\n");
    }

    // 2. LINQ DEMO
    static async Task DemoLINQ()
    {
        Console.WriteLine("🔍 LINQ DEMO - Querying and manipulating collections\n");

        var sampleEmployees = GetSampleEmployees();

        // LINQ Queries
        var highEarners = sampleEmployees
            .Where(e => e.Salary > 55000)
            .OrderByDescending(e => e.Salary)
            .Select(e => new { e.Name, e.Department, e.Salary });

        Console.WriteLine("High earners (> $55,000):");
        foreach (var emp in highEarners)
            Console.WriteLine($"  {emp.Name} ({emp.Department}): ${emp.Salary:N2}");

        // Group by department
        var deptGroups = sampleEmployees
            .GroupBy(e => e.Department)
            .Select(g => new
            {
                Department = g.Key,
                Count = g.Count(),
                AvgSalary = g.Average(e => e.Salary)
            });

        Console.WriteLine("\nDepartment Statistics:");
        foreach (var dept in deptGroups)
            Console.WriteLine($"  {dept.Department}: {dept.Count} employees, Avg Salary: ${dept.AvgSalary:N2}");

        // Complex LINQ with multiple operations
        var recentHires = sampleEmployees
            .Where(e => e.JoinDate > DateTime.Now.AddYears(-1))
            .OrderBy(e => e.JoinDate)
            .ToList();

        Console.WriteLine($"\nRecent hires (last year): {recentHires.Count}");

        Console.WriteLine("\n" + new string('-', 50) + "\n");
    }

    // 3. FILE SERIALIZATION DEMO
    static async Task DemoFileSerialization()
    {
        Console.WriteLine("💾 FILE SERIALIZATION DEMO - JSON Save/Load\n");

        var storage = new JsonStorage();
        var sampleEmployees = GetSampleEmployees();

        // Save to JSON
        Console.WriteLine("Saving employees to JSON file...");
        await storage.SaveEmployeesAsync(sampleEmployees);

        // Load from JSON
        Console.WriteLine("\nLoading employees from JSON file...");
        var loadedEmployees = await storage.LoadEmployeesAsync();

        Console.WriteLine($"\nSuccessfully loaded {loadedEmployees.Count} employees:");
        foreach (var emp in loadedEmployees.Take(3))
            Console.WriteLine($"  {emp}");

        Console.WriteLine("\n" + new string('-', 50) + "\n");
    }

    // 4. C# 14 FEATURES DEMO
    static void DemoCSharp14Features()
    {
        Console.WriteLine("✨ C# 14 FEATURES DEMO - Inline Arrays & Params Collections\n");

        // C# 14: Inline Arrays (performance optimization)
        Console.WriteLine("1. Inline Arrays (stack-allocated for performance):");
        var buffer = new Buffer8();
        for (int i = 0; i < 8; i++)
            buffer[i] = (byte)(i * 10);

        Console.Write("   Buffer values: ");
        for (int i = 0; i < 8; i++)
            Console.Write($"{buffer[i]} ");
        Console.WriteLine("\n   (Stack-allocated - no heap allocation!)");

        // C# 14: New params collections feature
        Console.WriteLine("\n2. Params Collections (flexible method parameters):");

        var result1 = CalculateSum(10, 20, 30, 40);
        var result2 = CalculateSum([50, 60, 70]);
        var numbers = new List<int> { 80, 90, 100 };
        var result3 = CalculateSum(numbers);

        Console.WriteLine($"   Sum with params ints: {result1}");
        Console.WriteLine($"   Sum with array: {result2}");
        Console.WriteLine($"   Sum with List<int>: {result3}");

        // Demonstrate performance benefit
        Console.WriteLine("\n   ✓ Params collections accept any IEnumerable type without array allocation!");

        Console.WriteLine("\n" + new string('-', 50));
    }

    // C# 14: Inline array (fixed size, stack-allocated)
    [InlineArray(8)]
    public struct Buffer8
    {
        private byte _element;
    }

    // C# 14: New params collections feature
    static int CalculateSum(params IEnumerable<int> numbers)
    {
        return numbers.Sum();
    }

    static List<Employee> GetSampleEmployees()
    {
        return
        [
            new Employee { Id = 1, Name = "Alice Johnson", Department = "Engineering", Salary = 75000, JoinDate = DateTime.Now.AddMonths(-3) },
            new Employee { Id = 2, Name = "Bob Smith", Department = "Sales", Salary = 62000, JoinDate = DateTime.Now.AddMonths(-8) },
            new Employee { Id = 3, Name = "Carol Davis", Department = "Engineering", Salary = 82000, JoinDate = DateTime.Now.AddMonths(-1) },
            new Employee { Id = 4, Name = "David Wilson", Department = "Marketing", Salary = 58000, JoinDate = DateTime.Now.AddMonths(-15) },
            new Employee { Id = 5, Name = "Eva Brown", Department = "Sales", Salary = 69000, JoinDate = DateTime.Now.AddMonths(-6) },
            new Employee { Id = 6, Name = "Frank Miller", Department = "Engineering", Salary = 71000, JoinDate = DateTime.Now.AddMonths(-10) }
        ];
    }
}