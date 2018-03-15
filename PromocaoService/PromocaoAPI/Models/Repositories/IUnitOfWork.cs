namespace PromocaoAPI.Models.Repositories
{
    public interface IUnitOfWork
    {
        PromocaoRepository PromocaoRepository { get; }
        void Save();
    }
}