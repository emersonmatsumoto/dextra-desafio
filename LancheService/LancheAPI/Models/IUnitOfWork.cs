namespace LancheAPI.Models
{
    public interface IUnitOfWork
{
    IGenericRepository<Lanche> LancheRepository { get; }
    IGenericRepository<Ingrediente> IngredienteRepository { get; }
    void Save();
}
}