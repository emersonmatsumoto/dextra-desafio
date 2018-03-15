namespace LancheAPI.Models.Repositories
{
    public interface IUnitOfWork
    {
        LancheRepository LancheRepository { get; }
        IngredienteRepository IngredienteRepository { get; }
        void Save();
    }
}