using System;

namespace Models
{
    public class Compra
    {
        /// <summary>
        /// Obtém ou define a lista de jogos comprados nesta compra.
        /// </summary>
        public List<Jogo> JogosComprados { get; set; }

        /// <summary>
        /// Obtém ou define a data e hora da compra.
        /// </summary>
        public DateTime DataCompra { get; set; }

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
    }
}
