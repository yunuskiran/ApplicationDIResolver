using ConsoleDI.Example.Lifetimes;

namespace ConsoleDI.Example.Scoped;

public interface IExampleScopedService : IReportServiceLifetime, IScopedLifetime
{
}