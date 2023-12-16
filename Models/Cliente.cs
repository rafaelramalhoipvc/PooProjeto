using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace Models
{
    /// <summary>
    /// Representa um cliente da loja de jogos, incluindo informações do perfil, histórico de compras e carrinho de compras.
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Obtém ou define o nome do cliente.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o endereço de e-mail do cliente.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Obtém ou define a senha do cliente.
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Obtém ou define o carrinho de compras do cliente.
        /// </summary>
        public CarrinhoDeCompras Carrinho { get; set; }

        /// <summary>
        /// Obtém ou define o histórico de compras do cliente.
        /// </summary>
        public List<Compra> HistoricoCompras { get; set; }

        public List<Jogo> jogosNoCarrinho = new List<Jogo>();
        private const string ComprasFolder = "HistoricoCompras";

        /// <summary>
        /// Obtém o caminho do ficheiro para armazenar o histórico de compras do cliente.
        /// </summary>
        private string ComprasFilePath => Path.Combine(ComprasFolder, $"{Nome}_historico_compras.json");

        /// <summary>
        /// Inicializa uma nova instância da classe Cliente.
        /// </summary>
        /// <param name="nome">O nome do cliente.</param>
        /// <param name="email">O endereço de e-mail do cliente.</param>
        /// <param name="senha">A senha do cliente.</param>
        public Cliente(string nome, string email, string senha)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Senha = senha ?? throw new ArgumentNullException(nameof(senha));
            Carrinho = new CarrinhoDeCompras(this);
            HistoricoCompras = new List<Compra>();
            
        }

       

        /// <summary>
        /// Edita o perfil do cliente, permitindo a alteração de nome, e-mail ou senha.
        /// </summary>
        /// <param name="cliente">O cliente cujo perfil está sendo editado.</param>
        public void EditarPerfil(Cliente cliente, List<Cliente>clientes)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine($"\n===== Editar Perfil de {cliente.Nome} =====");
                Console.WriteLine("1. Editar Nome");
                Console.WriteLine("2. Editar Email");
                Console.WriteLine("3. Editar Senha");
                Console.WriteLine("4. Voltar ao Menu Principal");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
         
                        Console.Write("Novo Nome: ");
                        string novoNome = Console.ReadLine();
                        cliente.Nome = novoNome;
                        Console.WriteLine("Nome atualizado com sucesso!");
                        break;
                    case "2":
                        Console.Write("Novo Email: ");
                        string novoEmail = Console.ReadLine();

                        // REGRA DE NEGOCIO - Verifica se o novo email já está em uso por outro cliente
                        if (clientes.Any(c => c.Email == novoEmail && c != cliente))
                        {
                            Console.WriteLine("Este email já está em uso. Escolha outro.");
                        }
                        else
                        {
                            cliente.Email = novoEmail;
                            Console.WriteLine("Email atualizado com sucesso!");
                        }
                        break;
                    case "3":
                        Console.Write("Nova Senha: ");
                        string novaSenha = Console.ReadLine();
                        cliente.Senha = novaSenha;
                        Console.WriteLine("Senha atualizada com sucesso!");
                        break;
                    case "4":
                        Console.WriteLine("Retornando ao Menu Principal...");
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        public void ApagarConta(Cliente cliente, List<Cliente> clientes)
        {
            Console.Clear();
            Console.WriteLine($"Tem mesmo a certeza que pretende apagar a sua conta? Ao fazer isso todos os seus dados irão ser removidos.");
            Console.Write("Tem certeza de que deseja continuar? (S/N): ");
            string confirmacao = Console.ReadLine().ToUpper();

            if (confirmacao == "S")
            {
                // REGRA DE NEGÓCIO - Autentica o cliente antes de permitir a exclusão
                Console.Write("Digite sua senha para confirmar a exclusão da conta: ");
                string senhaConfirmacao = Console.ReadLine();

                if (senhaConfirmacao == cliente.Senha)
                {
                    clientes.Remove(cliente);
                    GerirFicheiros.SalvarClientes(clientes); // Guarda a lista atualizada no ficheiro
                    Console.WriteLine("Conta removida com sucesso. Pressione qualquer tecla para encerrar o programa...");
                    Console.ReadKey();
                    Environment.Exit(0); // Encerra o programa
                }
                else
                {
                    Console.WriteLine("Senha incorreta. A exclusão da conta foi cancelada.");
                }
            }
            else
            {
                Console.WriteLine("Operação cancelada. Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }


        /// <summary>
        /// Adiciona um jogo ao carrinho de compras do cliente.
        /// </summary>
        /// <param name="jogos">A lista de jogos disponíveis.</param>
        public void AdicionarAoCarrinho(List<Jogo> jogos)
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

            Console.Write("Digite o nome do jogo que deseja adicionar ao carrinho: ");
            string nomeJogo = Console.ReadLine();

            Jogo jogoSelecionado = jogos.Find(j => j.Nome == nomeJogo);

            if (jogoSelecionado != null)
            {
                Console.Write($"Digite a quantidade desejada para {jogoSelecionado.Nome}: ");
                int quantidadeDesejada;
                while (!int.TryParse(Console.ReadLine(), out quantidadeDesejada) || quantidadeDesejada < 1)
                {
                    Console.WriteLine("Quantidade inválida. Digite novamente.");
                    Console.Write($"Digite a quantidade desejada para {jogoSelecionado.Nome}: ");
                }

                AdicionarQuantidadeAoCarrinho(jogoSelecionado, quantidadeDesejada);
            }
            else
            {
                Console.WriteLine($"Jogo com o nome '{nomeJogo}' não encontrado.");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Adiciona a quantidade especificada de um jogo ao carrinho de compras do cliente.
        /// </summary>
        /// <param name="jogo">O jogo a ser adicionado ao carrinho.</param>
        /// <param name="quantidade">A quantidade desejada do jogo.</param>
        public void AdicionarQuantidadeAoCarrinho(Jogo jogo, int quantidade)
        {
            if (quantidade > 0 && quantidade <= jogo.Quantidade)
            {
                Jogo jogoNoCarrinho = new Jogo
                {
                    Nome = jogo.Nome,
                    Preco = jogo.Preco,
                    Plataforma = jogo.Plataforma,
                    Genero = jogo.Genero,
                    Quantidade = quantidade
                };

                jogosNoCarrinho.Add(jogoNoCarrinho);
                Console.WriteLine($"{quantidade} cópias de {jogo.Nome} adicionadas ao carrinho.");
            }
            else
            {
                Console.WriteLine("Quantidade inválida ou insuficiente para adição ao carrinho. Tente novamente.");
            }
        }

        /// <summary>
        /// Visualiza o carrinho de compras do cliente, permitindo a finalização da compra ou remoção de itens.
        /// </summary>
        /// <param name="cliente">O cliente cujo carrinho está sendo visualizado.</param>
        /// <param name="jogos">A lista de jogos disponíveis.</param>
        public void VisualizarCarrinho(Cliente cliente, List<Jogo> jogos)
        {
            Console.Clear();
            Console.WriteLine("===== Carrinho de Compras =====");

            if (jogosNoCarrinho.Count > 0)
            {
                foreach (var jogo in jogosNoCarrinho)
                {
                    Console.WriteLine($"Nome: {jogo.Nome}\nQuantidade: {jogo.Quantidade}\nPreço Total: {jogo.Preco * jogo.Quantidade:C}\n");
                }

                Console.WriteLine("1. Finalizar Compra");
                Console.WriteLine("2. Remover Item");
                Console.WriteLine("3. Voltar ao Menu Principal");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Compra compra = new Compra(); // Criar uma instância de Compra
                        compra.RealizarCompra(cliente, jogos);
                        break;
                    case "2":
                        CarrinhoDeCompras carrinho = new CarrinhoDeCompras(cliente);
                        carrinho.RemoverDoCarrinho(cliente, jogos);
                        break;
                    case "3":
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Carrinho vazio. Adicione jogos antes de finalizar a compra.");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Salva o histórico de compras do cliente em um arquivo JSON.
        /// </summary>
        public void SalvarHistoricoCompras()
        {
            string json = JsonSerializer.Serialize(HistoricoCompras, new JsonSerializerOptions { WriteIndented = true });

            // Certifique-se de criar a pasta para armazenar os arquivos de histórico de compras
            if (!Directory.Exists(ComprasFolder))
            {
                Directory.CreateDirectory(ComprasFolder);
            }

            File.WriteAllText(ComprasFilePath, json);
        }

        /// <summary>
        /// Carrega o histórico de compras do cliente a partir de um arquivo JSON.
        /// </summary>
        public void CarregarHistoricoCompras()
        {
            try
            {
                if (File.Exists(ComprasFilePath))
                {
                    string json = File.ReadAllText(ComprasFilePath);
                    HistoricoCompras = JsonSerializer.Deserialize<List<Compra>>(json) ?? new List<Compra>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao carregar o histórico de compras: {ex.Message}");
            }
        }

    }
}
