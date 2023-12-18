/*
 
*
@file Compra.cs
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
    /// Representa uma compra realizada por um cliente na loja de jogos.
    /// </summary>
    public class Compra
    {
        #region Propriedades
        /// <summary>
        /// Obtém ou define a lista de jogos comprados nesta compra.
        /// </summary>
        public List<Jogo> JogosComprados { get; set; }

        /// <summary>
        /// Obtém ou define a data e hora da compra.
        /// </summary>
        public DateTime DataCompra { get; set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor que aceita a lista de jogos comprados, inicializando a data da compra para o momento atual.
        /// </summary>
        /// <param name="jogosComprados">A lista de jogos comprados nesta compra.</param>
        public Compra(List<Jogo> jogosComprados)
        {
            try
            {
                JogosComprados = jogosComprados;
                DataCompra = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao criar uma nova compra: {ex.Message}");
            }
        }

        /// <summary>
        /// Construtor padrão necessário para desserialização, inicializando a lista de jogos e a data da compra.
        /// </summary>
        public Compra()
        {
            JogosComprados = new List<Jogo>(); // Inicializa a lista para evitar null reference
            DataCompra = DateTime.Now;
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Finaliza a compra, atualizando a quantidade de jogos, registando a compra no histórico do cliente
        /// e guarda as alterações nos ficheiros.
        /// </summary>
        /// <param name="cliente">O cliente que está realizando a compra.</param>
        /// <param name="jogos">A lista de jogos disponíveis.</param>
        public void RealizarCompra(Cliente cliente, List<Jogo> jogos)
        {
            // Adicionar jogos no carrinho aos jogos disponíveis
            foreach (var jogoNoCarrinho in cliente.jogosNoCarrinho)
            {
                Jogo jogoOriginal = jogos.Find(j => j.Nome == jogoNoCarrinho.Nome);
                if (jogoOriginal != null)
                {
                    jogoOriginal.Quantidade -= jogoNoCarrinho.Quantidade;
                }
            }

            // Adicionar a compra ao histórico do cliente
            Compra novaCompra = new Compra(new List<Jogo>(cliente.jogosNoCarrinho));
            cliente.HistoricoCompras.Add(novaCompra);

            Console.WriteLine("Compra bem-sucedida! Obrigado por comprar conosco.");

            // Limpar carrinho
            cliente.jogosNoCarrinho.Clear();

            // Guarda os jogos atualizados no ficheiro
            GerirFicheiros.GuardarJogos(jogos);

            // Guarda o histórico de compras no ficheiro associado ao cliente
            cliente.GuardarHistoricoCompras();
        }
        #endregion
    }
}
