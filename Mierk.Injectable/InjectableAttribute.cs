namespace Mierk.Injectable;

[AttributeUsage(AttributeTargets.Class)]
public sealed class InjectableAttribute : Attribute
{
    public ServiceLifetimeMode Lifetime { get; }
    public IEnumerable<Type> ServiceTypes { get; }

    public InjectableAttribute(ServiceLifetimeMode lifetime, params Type[] serviceTypes)
    {
        Lifetime = lifetime;
        ServiceTypes = serviceTypes;
    }
}