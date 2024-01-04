/*
 
*
@file Program.cs
@author Nelson (a20743@alunos.ipca.pt)
@author Rafael (a16452@alunos.ipca.pt)
@brief
@date Dezembro
*
@copyright Copyright (c) 2023
*
*/

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

            GerirFicheiros.GuardarClientes(clientes);
            GerirFicheiros.GuardarAdministradores(administradores);
            GerirFicheiros.GuardarJogos(jogos);

            Console.WriteLine("Operações concluídas com sucesso!");
        }

        #region Métodos Principais

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
                        Cliente.RegistarCliente(clientes);
                        break;
                    case "2":
                        Login(clientes, administradores, jogos);
                        break;
                    case "3":
                        Console.WriteLine("Saindo do programa. Até breve!");
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
            Console.Write("Insira seu email: ");
            string email = Console.ReadLine();

            Console.Write("Insira sua senha: ");
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

        #endregion

        #region Métodos do Cliente

        #endregion
    }
}
