# Mierk.Injectable

Declarative Dependency Injection in .NET using attributes, lifetimes, and clean registration logic.

📦 NuGet: [Mierk.Injectable](https://www.nuget.org/packages/Mierk.Injectable)

📖 Blog post: [Declarative Dependency Injection in .NET](https://www.mierk.dev/blog/attribute-based-dependency-injection/)

🧑‍💻 Usage:
```csharp
[Injectable(ServiceLifetimeMode.Scoped, typeof(IMyService))]
public class MyService : IMyService { }
```

👉 Register via:
```csharp
builder.Services.RegisterInjectableServices([typeof(Program).Assembly]);
```