namespace PedidoAPI.Models
{
    public class Desconto : IEntity
    {
        public virtual Pedido Pedido { get; set; }        
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}