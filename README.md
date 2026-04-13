# Core Concepts Console Suite

## 📋 Project Overview

A comprehensive console application demonstrating fundamental C# and .NET concepts including LINQ, Async/Await, File Serialization, and C# 14 features.

## 🎯 Learning Objectives

- **LINQ**: Query and manipulate collections using Language Integrated Query
- **Async/Await**: Implement non-blocking asynchronous operations
- **File Serialization**: Save/load complex objects to/from JSON files
- **C# 14 Features**: Use inline arrays and params collections for performance

## 🚀 Technologies Used

| Technology | Version | Purpose |
|------------|---------|---------|
| .NET | 10.0 | Framework |
| C# | 14.0 | Programming Language |
| System.Text.Json | Built-in | JSON Serialization |
| Task Parallel Library | Built-in | Async Operations |

## 📦 Project Structure
Projact1/
├── README.md
├── Program.cs
├── Projact1.csproj
├── Models/
│   └── Employee.cs
├── Services/
│   ├── DataLoader.cs
│   └── JsonStorage.cs
└── employees.json (created at runtime) 



## 🔧 Installation & Setup

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download) or later
- Any code editor (Visual Studio 2022, VS Code, Rider)

### Steps to Run

1. **Clone or create the project**
   ```bash
   dotnet new console -n Projact1
   cd Projact1
