namespace PedidoAPI.Models.Repositories
{
    public interface IUnitOfWork
    {
        PedidoRepository PedidoRepository { get; }
        void Save();
    }
}