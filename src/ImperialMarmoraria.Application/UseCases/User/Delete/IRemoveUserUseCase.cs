namespace ImperialMarmoraria.Application.UseCases.User.Delete
{
    public interface IRemoveUserUseCase
    {
        Task Execute(long id);
    }
}
