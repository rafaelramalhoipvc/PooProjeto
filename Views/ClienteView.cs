using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Views
{
    public class ClienteView
    {
        /// <summary>
        /// Exibe o menu principal para o cliente interagir com a loja de jogos.
        /// </summary>
        /// <param name="cliente">O cliente que está interagindo com o menu.</param>
        /// <param name="jogos">A lista de jogos disponíveis.</param>
        public void ExibirMenuCliente(Cliente cliente, List<Jogo> jogos, List<Cliente> clientes)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine($"\n===== Bem-vindo, {cliente.Nome} =====");
                Console.WriteLine("                         C. Visualizar carrinho");
                Console.WriteLine("1. Listar Jogos Disponíveis");
                Console.WriteLine("2. Comprar Jogo");
                Console.WriteLine("3. Histórico");
                Console.WriteLine("4. Editar Perfil");
                Console.WriteLine("5. Apagar Conta");
                Console.WriteLine("6. Logout");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine().ToUpper(); // Converte para maiúsculas para aceitar 'C' ou 'c'

                switch (opcao)
                {
                    case "1":
                        ListarJogos(jogos);
                        break;
                    case "2":
                        cliente.AdicionarAoCarrinho(jogos);
                        break;
                    case "3":
                        VisualizarHistoricoCompras(cliente);
                        break;
                    case "C":
                        cliente.VisualizarCarrinho(cliente,jogos);
                        break;
                    case "4":
                        cliente.EditarPerfil(cliente, clientes);
                        break;
                    case "5":
                        cliente.ApagarConta(cliente, clientes);
                        break;
                    case "6":
                        Console.WriteLine($"Logout bem-sucedido. Até logo, {cliente.Nome}!");
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        /// <summary>
        /// Lista os jogos disponíveis, exibindo informações sobre preço, plataforma e gênero.
        /// </summary>
        /// <param name="jogos">A lista de jogos disponíveis.</param>
        public void ListarJogos(List<Jogo> jogos)
        {
            Console.Clear();
            Console.WriteLine("===== Jogos Disponíveis =====");
            if (jogos.Count > 0)
            {
                foreach (var jogo in jogos)
                {
                    if (jogo.Quantidade == 0)
                    {
                        Console.WriteLine($"Nome: {jogo.Nome}\nPreço: {jogo.Preco:C}\nPlataforma: {jogo.Plataforma}\nGênero: {jogo.Genero}\nESGOTADO\n");
                    }
                    else if (jogo.Quantidade < 10)
                    {
                        Console.WriteLine($"Nome: {jogo.Nome}\nPreço: {jogo.Preco:C}\nPlataforma: {jogo.Plataforma}\nGênero: {jogo.Genero}\nRESTAM POUCOS\n");
                    }
                    else
                    {
                        Console.WriteLine($"Nome: {jogo.Nome}\nPreço: {jogo.Preco:C}\nPlataforma: {jogo.Plataforma}\nGênero: {jogo.Genero}\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Não há jogos disponíveis no momento.");
            }

            Console.WriteLine("Prima qualquer tecla para regressar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Visualiza o histórico de compras do cliente, exibindo detalhes como a data da compra, jogos comprados
        /// e o preço total de cada jogo no momento da compra.
        /// </summary>
        public void VisualizarHistoricoCompras(Cliente cliente)
        {
            Console.Clear();
            Console.WriteLine($"===== Histórico de Compras de {cliente.Nome} =====");

            // Carregar o histórico de compras do arquivo
            cliente.CarregarHistoricoCompras(); 

            if (cliente.HistoricoCompras.Count > 0)
            {
                foreach (var compra in cliente.HistoricoCompras)
                {
                    Console.WriteLine($"Data da Compra: {compra.DataCompra}");
                    foreach (var jogo in compra.JogosComprados)
                    {
                        Console.WriteLine($"Nome: {jogo.Nome}\nQuantidade: {jogo.Quantidade}\nPreço Total: {jogo.Preco * jogo.Quantidade:C}\n");
                    }
                    Console.WriteLine("=============================");
                }
            }
            else
            {
                Console.WriteLine("Nenhum histórico de compras disponível.");
            }

            Console.WriteLine("Prima qualquer tecla para regressar ao menu....");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
