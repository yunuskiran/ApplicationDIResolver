using ConsoleDI.Example.Lifetimes;

namespace ConsoleDI.Example.Transist;

public interface IExampleTransientService : IReportServiceLifetime, ITransistLifetime
{
}
