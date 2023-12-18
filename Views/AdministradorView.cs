using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Views
{
    public class AdministradorView
    {
        /// <summary>
        /// Exibe o menu principal do administrador, permitindo a execução de várias operações na loja.
        /// </summary>
        /// <param name="admin">Instância do administrador.</param>
        /// <param name="administradores">Lista de administradores registrados.</param>
        /// <param name="jogos">Lista de jogos disponíveis na loja.</param>
        public void ExibirMenuAdministrador(Administrador admin, List<Administrador> administradores, List<Jogo> jogos)
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine($"\n===== Bem-vindo, {admin.Nome} =====");
                Console.WriteLine("1. Registar Administradores");
                Console.WriteLine("2. Adicionar Jogos");
                Console.WriteLine("3. Repor Stock");
                Console.WriteLine("4. Editar Jogo");
                Console.WriteLine("5. Logout");

                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        admin.RegistarAdministrador(administradores);
                        break;
                    case "2":
                        admin.AdicionarJogos(jogos);
                        break;
                    case "3":
                        admin.ReporStock(jogos);
                        break;
                    case "4":
                        admin.EditarJogo(jogos);
                        break;
                    case "5":
                        Console.WriteLine($"Logout bem-sucedido. Até breve, {admin.Nome}!");
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

    }
}
