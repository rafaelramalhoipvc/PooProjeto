﻿using System;
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



//-----------------------------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------------------------

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
    }
}
