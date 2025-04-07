namespace Mierk.Injectable.Tests.TestServices;

public interface ITransientService; 

[Injectable(ServiceLifetimeMode.Transient, typeof(ITransientService))]
public class TransientService : ITransientService;