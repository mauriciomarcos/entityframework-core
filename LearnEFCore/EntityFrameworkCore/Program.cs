using EntityFrameworkCore.Data.Repository;
using EntityFrameworkCore.Domain;
using EntityFrameworkCore.Domain.Interface.Repository;
using System;

namespace EntityFrameworkCore
{
    class Program
    {
        /*
         * Utilizar injeção de dependência para instanciar as classes de repositório, 
         * ou qualquer outra dependência que a classe eventualmento necessitar.
         */
        private static readonly IClienteRepository _clienteRepository = new ClienteRepository();

        static void Main(string[] args)
        {
            _clienteRepository.Add(new Cliente());
            Console.WriteLine("Hello World!");
        }
    }
}
