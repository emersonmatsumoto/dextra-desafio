namespace LancheAPI.Models 
{
    public class UnitOfWork : IUnitOfWork
{
    private readonly GenericDbContext _dbContext;
    private IGenericRepository<Lanche> _lancheRepository;
    private IGenericRepository<Ingrediente> _ingredienteRepository;
    public UnitOfWork(GenericDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IGenericRepository<Lanche> LancheRepository
    {
        get
        {
            return _lancheRepository = _lancheRepository ?? new GenericRepository<Lanche>(_dbContext);
        }
    }

    public IGenericRepository<Ingrediente> IngredienteRepository
    {
        get
        {
            return _ingredienteRepository = _ingredienteRepository ?? new GenericRepository<Ingrediente>(_dbContext);
        }
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}
}