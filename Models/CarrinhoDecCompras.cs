using System;

namespace Models
{
    /// <summary>
    /// Representa o carrinho de compras de um cliente na loja de jogos.
    /// </summary>
    public class CarrinhoDeCompras
    {
        /// <summary>
        /// Obtém ou define a lista de itens no carrinho.
        /// </summary>
        public List<Jogo> Itens { get; set; }
        /// <summary>
        /// Obtém ou define o cliente associado ao carrinho.
        /// </summary>
        public Cliente Comprador { get; set; }

        /// <summary>
        /// Inicializa uma nova instância da classe CarrinhoDeCompras.
        /// </summary>
        /// <param name="comprador">O cliente associado ao carrinho.</param>
        public CarrinhoDeCompras(Cliente comprador)
        {
            Comprador = comprador;
            Itens = new List<Jogo>();
        }

        /// <summary>
        /// Adiciona um jogo ao carrinho com a quantidade especificada.
        /// </summary>
        /// <param name="jogo">O jogo a ser adicionado ao carrinho.</param>
        /// <param name="quantidade">A quantidade desejada do jogo.</param>
        public void AdicionarJogoAoCarrinho(Jogo jogo, int quantidade)
        {
            Itens.Add(jogo);
        }

        /// <summary>
        /// Calcula o total do carrinho somando os preços de todos os jogos no carrinho.
        /// </summary>
        /// <returns>O valor total do carrinho.</returns>
        public double CalcularTotal()
        {
            double total = 0;
            foreach (var jogo in Itens)
            {
                total += jogo.Preco;
            }
            return total;
        }

        /// <summary>
        /// Remove um jogo específico do carrinho de compras do cliente.
        /// </summary>
        /// <param name="jogos">A lista de jogos disponíveis.</param>
        public void RemoverDoCarrinho(Cliente cliente, List<Jogo> jogos)
        {
            Console.Clear();
            Console.WriteLine("===== Remover do Carrinho =====");

            if (cliente.jogosNoCarrinho.Count > 0)
            {
                Console.WriteLine("Jogos no Carrinho:");

                for (int i = 0; i < cliente.jogosNoCarrinho.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {cliente.jogosNoCarrinho[i].Nome} - Quantidade: {cliente.jogosNoCarrinho[i].Quantidade}");
                }

                Console.Write("Escolha o número do jogo a ser removido: ");
                if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 1 && escolha <= cliente.jogosNoCarrinho.Count)
                {
                    // Remover o jogo escolhido do carrinho
                    Jogo jogoRemovido = cliente.jogosNoCarrinho[escolha - 1];
                    cliente.jogosNoCarrinho.Remove(jogoRemovido);

                    Console.WriteLine($"{jogoRemovido.Nome} removido do carrinho com sucesso.\n");
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("Carrinho vazio. Não há jogos para remover.");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }

}