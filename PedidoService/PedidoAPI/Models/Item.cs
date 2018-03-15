namespace PedidoAPI.Models
{
    public class Item : IEntity
    {
        public virtual Pedido Pedido { get; set; }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}