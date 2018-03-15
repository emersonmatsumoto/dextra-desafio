namespace PedidoAPI.Models.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GenericDbContext _dbContext;
        private PedidoRepository _pedidoRepository;
        public UnitOfWork(GenericDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PedidoRepository PedidoRepository
        {
            get
            {
                return _pedidoRepository = _pedidoRepository ?? new PedidoRepository(_dbContext);
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}