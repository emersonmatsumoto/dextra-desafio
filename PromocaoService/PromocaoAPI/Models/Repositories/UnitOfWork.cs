namespace PromocaoAPI.Models.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GenericDbContext _dbContext;
        private PromocaoRepository _promocaoRepository;

        public UnitOfWork(GenericDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PromocaoRepository PromocaoRepository
        {
            get
            {
                return _promocaoRepository = _promocaoRepository ?? new PromocaoRepository(_dbContext);
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}