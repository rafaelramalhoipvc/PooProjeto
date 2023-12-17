using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;
using Views;
using Controllers;

namespace LojaDeJogos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> clientes = GerirFicheiros.CarregarClientes();
            List<Administrador> administradores = GerirFicheiros.CarregarAdministradores();
            List<Jogo> jogos = GerirFicheiros.CarregarJogos();

            ExibirMenu(clientes, administradores, jogos);

            GerirFicheiros.SalvarClientes(clientes);
            GerirFicheiros.SalvarAdministradores(administradores);
            GerirFicheiros.SalvarJogos(jogos);

            Console.WriteLine("Operações concluídas com sucesso!");
        }

        /// <summary>
        /// Exibe o menu principal da aplicação.
        /// </summary>
        /// <param name="clientes">Lista de clientes.</param>
        /// <param name="administradores">Lista de administradores.</param>
        /// <param name="jogos">Lista de jogos.</param>
        public static void ExibirMenu(List<Cliente> clientes, List<Administrador> administradores, List<Jogo> jogos)
        {
            Console.Clear();
            Console.WriteLine("===== Bem-vindo à Loja de Jogos =====");

            while (true)
            {
                Console.WriteLine("\n===== Menu Principal =====");
                Console.WriteLine("1. Registar");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Sair");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RegistarCliente(clientes);
                        break;
                    case "2":
                        Login(clientes, administradores, jogos);
                        break;
                    case "3":
                        Console.WriteLine("Saindo do programa. Até logo!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        /// <summary>
        /// Realiza o login de um cliente ou administrador.
        /// </summary>
        /// <param name="clientes">Lista de clientes.</param>
        /// <param name="administradores">Lista de administradores.</param>
        /// <param name="jogos">Lista de jogos.</param>
        static void Login(List<Cliente> clientes, List<Administrador> administradores, List<Jogo> jogos)
        {
            Cliente clienteModel = new Cliente("Nome", "Email", "Senha");
            ClienteView clienteView = new ClienteView();
            ClienteController clienteController = new ClienteController(clienteModel, clienteView);
            Administrador administradorModel = new Administrador("Nome", "Email", "Senha");
            AdministradorView administradorView = new AdministradorView();
            AdministradorController administradorController = new AdministradorController(administradorModel, administradorView);

            Console.Clear();
            Console.Write("Digite seu email: ");
            string email = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();

            Cliente cliente = clientes.Find(c => c.Email == email && c.Senha == senha);
            Administrador admin = administradores.Find(a => a.Email == email && a.Senha == senha);

            if (cliente != null)
            {
                Console.WriteLine($"Login bem-sucedido como {cliente.Nome}!");
                clienteView.ExibirMenuCliente(cliente, jogos, clientes); 
            }
            else if (admin != null)
            {
                Console.WriteLine($"Login bem-sucedido como {admin.Nome}!");
                administradorView.ExibirMenuAdministrador(admin, administradores, jogos);

            }
            else
            {
                Console.WriteLine("Login falhou. Verifique suas credenciais e tente novamente.");
            }
        }


        //--------------------------------------------------------------------------------------------------------
        //PARTE DO ADMINISTRADOR

/// <summary>
/// Carrega a lista de administradores a partir de um arquivo JSON.
/// </summary>
/// <returns>Lista de administradores.</returns>
/*
static List<Administrador> CarregarAdministradores()
{
    List<Administrador> administradores = new List<Administrador>();
    string fileName = "administradores.json";

    if (File.Exists(fileName))
    {
        string json = File.ReadAllText(fileName);
        administradores = JsonSerializer.Deserialize<List<Administrador>>(json);
    }

    return administradores;
}

/// <summary>
/// Salva a lista de administradores em um arquivo JSON.
/// </summary>
/// <param name="administradores">Lista de administradores.</param>
static void SalvarAdministradores(List<Administrador> administradores)
{
    string fileName = "administradores.json";
    string json = JsonSerializer.Serialize(administradores, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(fileName, json);
}
*/
//-----------------------------------------------------------------------------------------------------------
/*
static Administrador LoginAdministrador(List<Administrador> administradores)
{
    Console.Clear();
    Console.Write("Digite seu email: ");
    string email = Console.ReadLine();

    Console.Write("Digite sua senha: ");
    string senha = Console.ReadLine();

    Administrador admin = administradores.Find(a => a.Email == email && a.Senha == senha);

    if (admin != null)
    {
        Console.WriteLine($"Login bem-sucedido como {admin.Nome}!");
        return admin;
    }
    else
    {
        Console.WriteLine("Login falhou. Verifique suas credenciais e tente novamente.");
        return null;
    }
}
*/
//-----------------------------------------------------------------------------------------------------------

/// <summary>
/// Carrega a lista de jogos a partir de um arquivo JSON.
/// </summary>
/// <returns>Lista de jogos.</returns>
/*
static List<Jogo> CarregarJogos()
{
    List<Jogo> jogos = new List<Jogo>();
    string fileName = "jogos.json";

    if (File.Exists(fileName))
    {
        string json = File.ReadAllText(fileName);
        jogos = JsonSerializer.Deserialize<List<Jogo>>(json);
    }

    return jogos;
}

/// <summary>
/// Salva a lista de jogos em um arquivo JSON.
/// </summary>
/// <param name="jogos">Lista de jogos.</param>
public static void SalvarJogos(List<Jogo> jogos)
{
    string fileName = "jogos.json";
    string json = JsonSerializer.Serialize(jogos, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText(fileName, json);
}



        */
//--------------------------------------------------------------------------------------------------------
//PARTE DO CLIENTE

/// <summary>
/// Registra um novo cliente.
/// </summary>
/// <param name="clientes">Lista de clientes.</param>
static void RegistarCliente(List<Cliente> clientes)
{
    Console.Clear();
    Console.Write("Digite seu nome: ");
    string nome = Console.ReadLine();

    Console.Write("Digite seu email: ");
    string email = Console.ReadLine();

    // REGRA DE NEGÓCIO - Verifica se já existe um cliente com o mesmo email
    if (clientes.Any(c => c.Email == email))
    {
        Console.WriteLine("Já existe um cliente registado com este email. Tente novamente com um email diferente.");
    }
    else
    {
        Console.Write("Digite sua senha: ");
        string senha = Console.ReadLine();

        Cliente novoCliente = new Cliente(nome, email, senha);
        clientes.Add(novoCliente);

        Console.WriteLine("Cliente registado com sucesso!");
        Console.Clear();
        }
}

        /// <summary>
        /// Carrega a lista de clientes a partir de um arquivo JSON.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        /*
        static List<Cliente> CarregarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            string fileName = "clientes.json";

            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                clientes = JsonSerializer.Deserialize<List<Cliente>>(json);
            }

            return clientes;
        }
        */
        /// <summary>
        /// Salva a lista de clientes em um arquivo JSON.
        /// </summary>
        /// <param name="clientes">Lista de clientes.</param>
        /*
        public static void SalvarClientes(List<Cliente> clientes)
        {
            string fileName = "clientes.json";

            // Criar uma lista de dados específica para a serialização
            var clientesParaSerializar = clientes.Select(c => new
            {
                Nome = c.Nome,
                Email = c.Email,
                Senha = c.Senha
                // Adicione outras propriedades conforme necessário, evitando referências circulares
            }).ToList();

            string json = JsonSerializer.Serialize(clientesParaSerializar, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }
                */
    }
}

/*
static Cliente LoginCliente(List<Cliente> clientes)
{
Console.Clear();
Console.Write("Digite seu email: ");
string email = Console.ReadLine();

Console.Write("Digite sua senha: ");
string senha = Console.ReadLine();

Cliente cliente = clientes.Find(c => c.Email == email && c.Senha == senha);

if (cliente != null)
{
Console.WriteLine($"Login bem-sucedido como {cliente.Nome}!");
return cliente;
}
else
{
Console.WriteLine("Login falhou. Verifique suas credenciais e tente novamente.");
return null;
}
}
*/



/*
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace LojaDeJogos
{
    // Classe principal do programa
    class Program
    {
        static void Main(string[] args)
        {
            
            
                List<Cliente> clientes = CarregarClientes();


                SalvarClientes(clientes);
                //aaaaa
                Console.WriteLine("Clientes salvos com sucesso!");
            // Criando um estoque inicial de jogos
            List<Jogo> StockJogos = new List<Jogo>
            {
                new Jogo("The Witcher 3", 49.99, "PC", "RPG"),
                new Jogo("FIFA 22", 59.99, "PS5", "Esportes"),
                new Jogo("Assassin's Creed Valhalla", 39.99, "Xbox Series X", "Ação")
            };
            

            // Criando um administrador
            Administrador admin = new Administrador("Admin", "admin@email.com", "senhaAdmin");



            // Exibindo o menu inicial
            ExibirMenu(clientes, StockJogos, admin);
        }

        // Função para exibir o menu principal
        static void ExibirMenu(List<Cliente> clientes, List<Jogo> StockJogos, Administrador admin)
        {
            Console.WriteLine("===== Bem-vindo à Loja de Jogos =====");

            while (true)
            {
                Console.WriteLine("\n===== Menu Principal =====");
                Console.WriteLine("1. Login como Cliente");
                Console.WriteLine("2. Login como Admin");
                Console.WriteLine("3. Register cliente");
                Console.WriteLine("4. Sair");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        LoginCliente(clientes, StockJogos);
                        break;
                    case "2":
                        LoginAdmin(admin, StockJogos);
                        break;
                    case "3":
                        RegistrarCliente(clientes);
                        break;
                    case "4":
                        Console.WriteLine("Saindo do programa. Até logo!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void RegistrarCliente(List<Cliente> clientes)
        {
            Console.Clear();
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite seu email: ");
            string email = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();

            Cliente novoCliente = new Cliente(nome, email, senha);
            clientes.Add(novoCliente);

            Console.WriteLine("Cliente registrado com sucesso!");
        }

        // Função para realizar o login como cliente
        static void LoginCliente(List<Cliente> clientes, List<Jogo> StockJogos)
        {
            Console.Write("Digite seu email: ");
            string email = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();

            Cliente cliente = clientes.Find(c => c.Email == email && c.Senha == senha);

            if (cliente != null)
            {
                Console.WriteLine($"Login bem-sucedido como {cliente.Nome}!");
                ExibirMenuCliente(cliente, StockJogos);
            }
            else
            {
                Console.WriteLine("Login falhou. Verifique suas credenciais e tente novamente.");
            }
        }

        // Função para realizar o login como administrador
        static void LoginAdmin(Administrador admin, List<Jogo> StockJogos)
        {
            if (admin == null)
            {
                Console.WriteLine("Login de administrador não disponível. Não há admin cadastrado.");
                return;
            }

            Console.Write("Digite o nome de usuário do admin: ");
            string username = Console.ReadLine();

            Console.Write("Digite a senha do admin: ");
            string senha = Console.ReadLine();

            if (admin.ValidarLogin(username, senha))
            {
                Console.WriteLine($"Login bem-sucedido como Admin!");
                ExibirMenuAdmin(StockJogos);
            }
            else
            {
                Console.WriteLine("Login de admin falhou. Verifique suas credenciais e tente novamente.");
            }
        }

        // Função para exibir o menu do cliente após o login
        static void ExibirMenuCliente(Cliente cliente, List<Jogo> StockJogos)
        {
            while (true)
            {
                Console.WriteLine($"\n===== Bem-vindo, {cliente.Nome} =====");
                Console.WriteLine("1. Listar Jogos Disponíveis");
                Console.WriteLine("2. Comprar Jogo");
                Console.WriteLine("3. Logout");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ListarJogosDisponiveis(StockJogos);
                        break;
                    case "2":
                        ComprarJogo(cliente, StockJogos);
                        break;
                    case "3":
                        Console.WriteLine($"Logout bem-sucedido. Até logo, {cliente.Nome}!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
        static List<Cliente> CarregarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            string fileName = "clientes.json";

            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                clientes = JsonSerializer.Deserialize<List<Cliente>>(json);
            }

            return clientes;
        }

        static void SalvarClientes(List<Cliente> clientes)
        {
            string fileName = "clientes.json";
            string json = JsonSerializer.Serialize(clientes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }


        // Função para exibir o menu do administrador após o login
        static void ExibirMenuAdmin(List<Jogo> StockJogos)
        {
            while (true)
            {
                Console.WriteLine("\n===== Menu do Administrador =====");
                Console.WriteLine("1. Adicionar Jogo ao Estoque");
                Console.WriteLine("2. Listar Jogos no Estoque");
                Console.WriteLine("3. Logout");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarJogoAoEstoque(StockJogos);
                        break;
                    case "2":
                        ListarJogosDisponiveis(StockJogos);
                        break;
                    case "3":
                        Console.WriteLine("Logout de administrador bem-sucedido. Até logo!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        // Função para listar os jogos disponíveis no estoque
        static void ListarJogosDisponiveis(List<Jogo> StockJogos)
        {
            Console.WriteLine("\n===== Jogos Disponíveis =====");
            foreach (var jogo in StockJogos)
            {
                Console.WriteLine($"Nome: {jogo.Nome}, Plataforma: {jogo.Plataforma}, Preço: {jogo.Preco:C}");
            }
        }

        // Função para permitir que um cliente compre um jogo
        static void ComprarJogo(Cliente cliente, List<Jogo> StockJogos)
        {
            ListarJogosDisponiveis(StockJogos);

            Console.Write("Digite o nome do jogo que deseja comprar: ");
            string nomeJogo = Console.ReadLine();

            Jogo jogoParaComprar = StockJogos.Find(j => j.Nome == nomeJogo);

            if (jogoParaComprar != null)
            {
                CarrinhoDeCompras carrinho = new CarrinhoDeCompras(cliente);
                carrinho.AdicionarJogoAoCarrinho(jogoParaComprar);

                Fatura fatura = new Fatura(carrinho);
                fatura.ImprimirFatura();

                // Removendo o jogo do estoque
                StockJogos.Remove(jogoParaComprar);
            }
            else
            {
                Console.WriteLine("Jogo não encontrado no estoque.");
            }
        }

        // Função para adicionar um novo jogo ao estoque (incompleta, precisa ser implementada)
        static void AdicionarJogoAoEstoque(List<Jogo> StockJogos)
        {
            Console.Write("Digite o nome do jogo: ");
            string nomeJogo = Console.ReadLine();

            Console.Write("Digite o preço do jogo: ");
            double precoJogo = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite a plataforma do jogo: ");
            string plataformaJogo = Console.ReadLine();

            Console.Write("Digite o gênero do jogo: ");
            string generoJogo = Console.ReadLine();

            Jogo novoJogo = new Jogo(nomeJogo, precoJogo, plataformaJogo, generoJogo);
            StockJogos.Add(novoJogo);

            Console.WriteLine("Jogo adicionado ao estoque com sucesso!");
        }
    }
}

// ta a funcionar
        static void AdicionarJogo(Administrador admin, List<Jogo> jogos)
        {
            Console.Clear();
            Console.Write("Digite o nome do jogo: ");
            string nomeJogo = Console.ReadLine();

            Console.Write("Digite o preço do jogo: ");
            double precoJogo;
            while (!double.TryParse(Console.ReadLine(), out precoJogo))
            {
                Console.WriteLine("Digite um valor numérico válido para o preço.");
                Console.Write("Digite o preço do jogo: ");
            }

            Console.Write("Digite a plataforma do jogo: ");
            string plataformaJogo = Console.ReadLine();

            Console.Write("Digite o gênero do jogo: ");
            string generoJogo = Console.ReadLine();

            Jogo novoJogo = new Jogo(nomeJogo, precoJogo, plataformaJogo, generoJogo);
            jogos.Add(novoJogo);

            Console.WriteLine("Jogo adicionado com sucesso!");
        }

        static void SalvarJogos(List<Jogo> jogos)
        {
            string fileName = "jogos.json";
            string json = JsonSerializer.Serialize(jogos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }

        static List<Jogo> CarregarJogos()
        {
            List<Jogo> jogos = new List<Jogo>();
            string fileName = "jogos.json";

            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                jogos = JsonSerializer.Deserialize<List<Jogo>>(json);
            }

            return jogos;
        }

static void ListarJogos(List<Jogo> jogos)
        {
            Console.Clear();
            Console.WriteLine("===== Jogos Disponíveis =====");

            foreach (var jogo in jogos)
            {
                Console.WriteLine($"Nome: {jogo.Nome}, Preço: {jogo.Preco}, Plataforma: {jogo.Plataforma}, Gênero: {jogo.Genero}");
            }

            Console.WriteLine("\nPressione Enter para voltar ao menu.");
            Console.ReadLine();
        }

 static void ListarJogos(Cliente cliente, List<Jogo> jogos)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Jogos Disponíveis =====");

                foreach (var jogo in jogos)
                {
                    Console.WriteLine($"Nome: {jogo.Nome}, Preço: {jogo.Preco}, Plataforma: {jogo.Plataforma}, Gênero: {jogo.Genero}");
                }

                Console.WriteLine("\nPressione Enter para voltar ao menu.");

                // Aguardar a tecla Enter ser pressionada
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    // Aguardar até que a tecla Enter seja pressionada
                }

                // Voltar ao menu
                ExibirMenuCliente(cliente, jogos);
            }
        }

*/