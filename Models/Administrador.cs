/*
 
*
@file Administrador.cs
@author Nelson (a20743@alunos.ipca.pt)
@author Rafael (a16452@alunos.ipca.pt)
@brief
@date Dezembro
*
@copyright Copyright (c) 2023
*
*/
using System;

namespace Models
{
    /// <summary>
    /// Representa um administrador da loja de jogos, incluindo informações do perfil.
    /// </summary>
    public class Administrador
    {
        #region Propriedades
        /// <summary>
        /// Obtém ou define o nome do administrador.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o email do administrador.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Obtém ou define a senha do administrador.
        /// </summary>
        public string Senha { get; set; }
        #endregion

        #region Construtor

        /// <summary>
        /// Inicializa uma nova instância da classe Administrador.
        /// </summary>
        /// <param name="nome">Nome do administrador.</param>
        /// <param name="email">Email do administrador.</param>
        /// <param name="senha">Senha do administrador.</param>
        public Administrador(string nome, string email, string senha)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Senha = senha ?? throw new ArgumentNullException(nameof(senha));
        }
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Regista um novo administrador e adiciona-o à lista de administradores.
        /// </summary>
        /// <param name="administradores">Lista de administradores registados.</param>
        public void RegistarAdministrador(List<Administrador> administradores)
        {
            Console.Clear();
            Console.Write("Insere o nome do administrador: ");
            string nome = Console.ReadLine();

            Console.Write("Insere o email do administrador: ");
            string email = Console.ReadLine();

            // REGRA DE NEGÓCIO - Verifica se já existe um administrador com o mesmo email
            if (administradores.Any(a => a.Email == email))
            {
                Console.WriteLine("Já existe um administrador registado com este email. Tente novamente com um email diferente.");
            }
            else
            {
                Console.Write("Insira a senha do administrador: ");
                string senha = Console.ReadLine();

                Administrador novoAdministrador = new Administrador(nome, email, senha);
                administradores.Add(novoAdministrador);

                Console.WriteLine("Administrador registado com sucesso!");
            }
        }

        /// <summary>
        /// Adiciona um novo jogo à lista de jogos disponíveis na loja.
        /// </summary>
        /// <param name="jogos">Lista de jogos disponíveis na loja.</param>
        public void AdicionarJogos(List<Jogo> jogos)
        {
            Console.Clear();
            Console.WriteLine("===== Adicionar Jogo =====");

            Console.Write("Nome do Jogo: ");
            string nome = Console.ReadLine();

            Console.Write("Preço do Jogo: ");
            double preco;
            while (!double.TryParse(Console.ReadLine(), out preco))
            {
                Console.WriteLine("Por favor, insira um valor válido para o preço.");
                Console.Write("Preço do Jogo: ");
            }

            Console.Write("Plataforma do Jogo: ");
            string plataforma = Console.ReadLine();

            Console.Write("Gênero do Jogo: ");
            string genero = Console.ReadLine();

            Console.Write("Quantidade do Jogo: ");
            int quantidade;
            while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 0)
            {
                Console.WriteLine("Por favor, insira um valor inteiro não negativo para a quantidade.");
                Console.Write("Quantidade do Jogo: ");
            }

            Jogo novoJogo = new Jogo(nome, preco, plataforma, genero, quantidade);
            jogos.Add(novoJogo);

            Console.WriteLine("Jogo adicionado com sucesso!");
        }

        /// <summary>
        /// Repõe o stock de um jogo específico, adicionando uma quantidade adicional ao stock atual.
        /// </summary>
        /// <param name="jogos">Lista de jogos disponíveis na loja.</param>
        public void ReporStock(List<Jogo> jogos)
        {
            Console.Clear();
            Console.WriteLine("===== Repor Stock =====");

            Console.Write("Digite o nome do jogo para repor o stock: ");
            string nomeJogo = Console.ReadLine();

            Jogo jogoSelecionado = jogos.Find(j => j.Nome == nomeJogo);

            if (jogoSelecionado != null)
            {
                Console.Write($"Quantidade atual de {jogoSelecionado.Nome}: {jogoSelecionado.Quantidade}\n");

                Console.Write("Digite a quantidade para adicionar ao stock: ");
                int quantidadeAdicional;
                while (!int.TryParse(Console.ReadLine(), out quantidadeAdicional) || quantidadeAdicional < 0)
                {
                    Console.WriteLine("Por favor, insira um valor inteiro não negativo para a quantidade.");
                    Console.Write("Digite a quantidade para adicionar ao stock: ");
                }

                jogoSelecionado.Quantidade += quantidadeAdicional;

                Console.WriteLine($"Stock de {jogoSelecionado.Nome} atualizado para {jogoSelecionado.Quantidade} unidades.");
            }
            else
            {
                Console.WriteLine($"Jogo com o nome '{nomeJogo}' não encontrado.");
            }

            Console.WriteLine("Prima qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Edita as informações de um jogo existente na lista de jogos.
        /// </summary>
        /// <param name="jogos">Lista de jogos disponíveis na loja.</param>
        public void EditarJogo(List<Jogo> jogos)
        {
            Console.Clear();
            Console.WriteLine("===== Editar Jogo =====");

            // Exibir a lista de jogos para que o administrador escolha qual editar
            Console.WriteLine("Lista de Jogos:");
            for (int i = 0; i < jogos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {jogos[i].Nome}");
            }

            Console.Write("Escolha o número do jogo a ser editado: ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 1 && escolha <= jogos.Count)
            {
                Jogo jogoParaEditar = jogos[escolha - 1];

                // Exibir informações atuais do jogo
                Console.WriteLine($"Editando o jogo: {jogoParaEditar.Nome}");
                Console.WriteLine($"1. Nome: {jogoParaEditar.Nome}");
                Console.WriteLine($"2. Preço: {jogoParaEditar.Preco:C}");
                Console.WriteLine($"3. Plataforma: {jogoParaEditar.Plataforma}");
                Console.WriteLine($"4. Gênero: {jogoParaEditar.Genero}");

                Console.Write("Escolha o número do atributo a ser editado: ");
                if (int.TryParse(Console.ReadLine(), out int atributoEscolhido) && atributoEscolhido >= 1 && atributoEscolhido <= 5)
                {
                    // Solicitar o novo valor
                    Console.Write("Novo valor: ");
                    string novoValor = Console.ReadLine();

                    // Atualizar o atributo escolhido
                    switch (atributoEscolhido)
                    {
                        case 1:
                            jogoParaEditar.Nome = novoValor;
                            break;
                        case 2:
                            if (double.TryParse(novoValor, out double novoPreco))
                                jogoParaEditar.Preco = novoPreco;
                            else
                                Console.WriteLine("Valor inválido para o preço. Nenhuma alteração realizada.");
                            break;
                        case 3:
                            jogoParaEditar.Plataforma = novoValor;
                            break;
                        case 4:
                            jogoParaEditar.Genero = novoValor;
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Nenhuma alteração realizada.");
                            break;
                    }

                    Console.WriteLine("Edição concluída com sucesso!");
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Nenhuma alteração realizada.");
                }
            }
            else
            {
                Console.WriteLine("Escolha inválida. Nenhuma alteração realizada.");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }

        #endregion

    }
}
