using System.Collections.Generic;
using System.IO;
using System.Linq;  // Adicionei este using para a extensão Select
using System.Text.Json;

namespace Models  // Corrigi o nome do namespace
{
    public static class GerirFicheiros
    {
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

        public static void GuardarAdministradores(List<Administrador> administradores)
        {
            string fileName = "administradores.json";
            string json = JsonSerializer.Serialize(administradores, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }

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

        public static void GuardarJogos(List<Jogo> jogos)
        {
            string fileName = "jogos.json";
            string json = JsonSerializer.Serialize(jogos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }

    }
}
