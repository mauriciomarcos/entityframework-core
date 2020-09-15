using EntityFrameworkCore.ValueObjects;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public TipoFrete TipoFrete { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public string Observacao { get; set; }
        public ICollection<PedidoItem> ItensPedido { get; set; }
    }
}
