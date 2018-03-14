namespace LancheAPI.Models 
{
    public class Ingrediente : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}