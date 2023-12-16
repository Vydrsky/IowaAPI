namespace Iowa.Application._Common.Interfaces.Persistence.Base;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
