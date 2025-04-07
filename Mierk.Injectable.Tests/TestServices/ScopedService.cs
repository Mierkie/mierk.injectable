namespace Mierk.Injectable.Tests.TestServices;

public interface IScopedService;

[Injectable(ServiceLifetimeMode.Scoped, typeof(IScopedService))]
public class ScopedService : IScopedService;