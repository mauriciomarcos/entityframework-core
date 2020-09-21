using EntityFrameworkCore.Data.Repository;
using EntityFrameworkCore.Domain;
using EntityFrameworkCore.Domain.Interface.Repository;
using EntityFrameworkCore.ValueObjects;
using System;
using System.Collections.Generic;

namespace EntityFrameworkCore
{
    class Program
    {
        /*
         * Utilizar injeção de dependência para instanciar as classes de repositório, 
         * ou qualquer outra dependência que a classe eventualmente necessitar.
         */
        private static readonly IClienteRepository _clienteRepository = new ClienteRepository();
        private static readonly IPedidoRepository _pedidoRepository = new PedidoRepository();

        static void Main(string[] args)
        {
            // Inserindo registro de uma única instância de Cliente à base de dados
            //var cliente = ClienteFactory();
            //_clienteRepository.Add(cliente);
            //Console.WriteLine($"adicionado o cliente {cliente.Nome} adicionado!");

            /*
             * Inserindo: Composição completa de um pedido:
             *  1- Cliente
             *  2- Pedido
             *  3- Produto
             *  4- ItemPedido
             */
            var pedido = PedidoFactory();
            _pedidoRepository.Add(pedido);
        }

        private static Pedido PedidoFactory()
        {
            var cliente = _clienteRepository.GetById(14);
            var produto = new Produto
            {
                Descricao = "Smart Phone Moto",
                Valor = 999.99M,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                CodigoBarras = "000215.5520025"
            };
            var produto2 = new Produto
            {
                Descricao = "PS 5",
                Valor = 3500.99M,
                TipoProduto = TipoProduto.Servico,
                CodigoBarras = "005666.00000.0"
            };
            var pedido = new Pedido
            {
                ClienteId = cliente.Id,
                DataInicio = DateTime.Now,
                Observacao = "Entrega expressa",
                TipoFrete = TipoFrete.CIF,
                StatusPedido = StatusPedido.Analise
            };

            List<PedidoItem> itens = new List<PedidoItem>();
            var itensPedido = new PedidoItem
            {
                Produto = produto,
                Pedido = pedido,
                Quantidade = 1,
                ValorUnitarioProduto = (produto.Valor * 0.05M),
                Desconto = 0.00M
            };
            var itensPedido2 = new PedidoItem
            {
                Produto = produto2,
                Pedido = pedido,
                Quantidade = 10,
                ValorUnitarioProduto = (produto2.Valor - (produto2.Valor * 0.1M)),
                Desconto = ((produto2.Valor * 0.1M) * 10)
            };

            itens.Add(itensPedido);
            itens.Add(itensPedido2);

            pedido.ItensPedido = itens;

            return pedido;
        }

        private static Cliente ClienteFactory()
        {
            return new Cliente
            {
                Nome = "Maurício Marcos",
                Email = "001.mmarcos@gmail.com",
                Telefone = "16992339155",
                Cidade = "Araraquara",
                Estado = "SP",
                CEP = "14801145"
            };
        }
    }
}
