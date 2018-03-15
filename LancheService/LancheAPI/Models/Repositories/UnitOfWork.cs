namespace LancheAPI.Models.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GenericDbContext _dbContext;
        private LancheRepository _lancheRepository;
        private IngredienteRepository _ingredienteRepository;
        public UnitOfWork(GenericDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public LancheRepository LancheRepository
        {
            get
            {
                return _lancheRepository = _lancheRepository ?? new LancheRepository(_dbContext);
            }
        }

        public IngredienteRepository IngredienteRepository
        {
            get
            {
                return _ingredienteRepository = _ingredienteRepository ?? new IngredienteRepository(_dbContext);
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}