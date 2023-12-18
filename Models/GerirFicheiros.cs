/*
 
*
@file GerirFicheiros.cs
@author Nelson (a20743@alunos.ipca.pt)
@author Rafael (a16452@alunos.ipca.pt)
@brief
@date Dezembro
*
@copyright Copyright (c) 2023
*
*/
using System.Collections.Generic;
using System.IO;
using System.Linq;  
using System.Text.Json;

namespace Models 
{
    /// <summary>
    /// Classe estática para gerenciamento de leitura e escrita de dados em ficheiros.
    /// </summary>
    public static class GerirFicheiros
    {
        #region Clientes

        /// <summary>
        /// Carrega a lista de clientes a partir de um arquivo JSON.
        /// </summary>
        /// <returns>Lista de clientes carregada do arquivo.</returns>
        public static List<Cliente> CarregarClientes()
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

        /// <summary>
        /// Guarda a lista de clientes em um arquivo JSON.
        /// </summary>
        /// <param name="clientes">Lista de clientes a ser salva.</param>
        public static void GuardarClientes(List<Cliente> clientes)
        {
            string fileName = "clientes.json";

            var clientesParaSerializar = clientes.Select(c => new
            {
                Nome = c.Nome,
                Email = c.Email,
                Senha = c.Senha
            }).ToList();

            string json = JsonSerializer.Serialize(clientesParaSerializar, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }
        #endregion

        #region Administradores

        // <summary>
        /// Carrega a lista de administradores a partir de um arquivo JSON.
        /// </summary>
        /// <returns>Lista de administradores carregada do arquivo.</returns>
        public static List<Administrador> CarregarAdministradores()
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
        /// Guarda a lista de administradores em um arquivo JSON.
        /// </summary>
        /// <param name="administradores">Lista de administradores a ser salva.</param>
        public static void GuardarAdministradores(List<Administrador> administradores)
        {
            string fileName = "administradores.json";
            string json = JsonSerializer.Serialize(administradores, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }
        #endregion

        #region Jogos

        /// <summary>
        /// Carrega a lista de jogos a partir de um arquivo JSON.
        /// </summary>
        /// <returns>Lista de jogos carregada do arquivo.</returns>
        public static List<Jogo> CarregarJogos()
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
        /// Guarda a lista de jogos em um arquivo JSON.
        /// </summary>
        /// <param name="jogos">Lista de jogos a ser salva.</param>
        public static void GuardarJogos(List<Jogo> jogos)
        {
            string fileName = "jogos.json";
            string json = JsonSerializer.Serialize(jogos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }
        #endregion

    }
}
