namespace ImperialMarmoraria.Domain.Repositories;
public interface IUnityOfWork
{
    Task Commit();
}
