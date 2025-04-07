namespace Mierk.Injectable.Tests.Invalid.TestServices;

public interface INotImplemented { }

[Injectable(ServiceLifetimeMode.Scoped, typeof(INotImplemented))]
public class InvalidService { }
