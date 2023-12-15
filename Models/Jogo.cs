using System;


namespace Models
{
    public class Jogo
    {
        /// <summary>
        /// Obtém ou define o nome do jogo.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Obtém ou define o preço do jogo.
        /// </summary>
        public double Preco { get; set; }

        /// <summary>
        /// Obtém ou define a plataforma na qual o jogo está disponível.
        /// </summary>
        public string Plataforma { get; set; }

        /// <summary>
        /// Obtém ou define o gênero do jogo.
        /// </summary>
        public string Genero { get; set; }

        /// <summary>
        /// Obtém ou define a quantidade de cópias disponíveis do jogo.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Construtor padrão sem parâmetros para a desserialização JSON.
        /// </summary>
        public Jogo() // Construtor padrão sem parâmetros para a desserialização JSON
        {
        }

        /// <summary>
        /// Realiza a compra do jogo, reduzindo a quantidade disponível.
        /// </summary>
        /// <param name="quantidade">A quantidade de cópias a serem compradas.</param>
        public void Comprar(int quantidade)
        {
            if (quantidade > 0 && quantidade <= Quantidade)
            {
                Quantidade -= quantidade;
                Console.WriteLine($"Compra bem-sucedida! {quantidade} cópias de {Nome} foram adquiridas.");
            }
            else
            {
                Console.WriteLine("Quantidade inválida ou insuficiente para compra. Tente novamente.");
            }
        }
        /// <summary>
        /// Inicializa uma nova instância da classe Jogo com as informações fornecidas.
        /// </summary>
        /// <param name="nome">O nome do jogo.</param>
        /// <param name="preco">O preço do jogo.</param>
        /// <param name="plataforma">A plataforma na qual o jogo está disponível.</param>
        /// <param name="genero">O gênero do jogo.</param>
        /// <param name="quantidade">A quantidade de cópias disponíveis do jogo.</param>
        public Jogo(string nome, double preco, string plataforma, string genero, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Plataforma = plataforma;
            Genero = genero;
            Quantidade = quantidade;
        }


    }
}