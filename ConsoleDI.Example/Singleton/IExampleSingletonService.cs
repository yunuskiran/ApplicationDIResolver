using ConsoleDI.Example.Lifetimes;

namespace ConsoleDI.Example.Singleton;

public interface IExampleSingletonService : IReportServiceLifetime, ISingletonLifetime
{
}