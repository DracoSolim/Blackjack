using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Blackjack
{
    internal class master
    {
        class Program
        {
            static void Principal()
            {
                //Crear un nuevo mazo aleatorio
                Deck deck = new Deck();
                deck.Iniciar();

                //Aleatorizar el mazo
                deck.Mezclar();

                //Elegir y mostrar una carta aleatoria
                Carta randomCard = deck.CartaAleatoria();
                Console.WriteLine($"Carta aleatoria: {randomCard.Numero} de {randomCard.Tipo}");
            }
        }

        class Carta
        {
            public string Numero { get; set; }
            public string Tipo { get; set; }

            public Carta(string numero, string tipo)
            {
                Numero = numero;
                Tipo = tipo;
            }
        }

        class Deck
        {
            private List<Carta> cartas;

            public void Iniciar()
            {
                cartas = new List<Carta>();

                string[] numero = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
                string[] tipo = { "Hearts", "Diamonds", "Clubs", "Spades" };

                foreach (string suit in tipo)
                {
                    foreach (string rank in numero)
                    {
                        cartas.Add(new Carta(rank, suit));
                    }
                }
            }

            public void Mezclar()
            {
                Random random = new Random();
                int n = cartas.Count;
                while (n > 1)
                {
                    n--;
                    int k = random.Next(n + 1);
                    Carta value = cartas[k];
                    cartas[k] = cartas[n];
                    cartas[n] = value;
                }
            }

            public Carta CartaAleatoria()
            {
                if (cartas.Count == 0)
                {
                    MessageBox.Show("La baraja se quedo sin cartas");
                }

                Random random = new Random();
                int randomIndex = random.Next(cartas.Count);
                Carta drawnCard = cartas[randomIndex];
                cartas.RemoveAt(randomIndex);

                return drawnCard;
            }
        }
    }
}