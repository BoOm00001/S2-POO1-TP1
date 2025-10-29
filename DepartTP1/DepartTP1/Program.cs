using DepartTP1;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace SolutionTP1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int CARDSIZE = 0;
            bool weGotWinner = false;
            int newNumber = 0;
            int nbOfDraws = 0;
            int winnerIndex = 0;

            List<BingoCard> allCards = new List<BingoCard>();             //Collections de cartes Bingo.
            List<int> abacus = new List<int>();                          //J'ai cherché le mot boulier en anglais et google m'a donné abacus...  Collections des tirages.
            NumberGenerator draws = new NumberGenerator(8473718269L);   

            //Instantiation des 5 cartes de Bingos.

            NumberGenerator numberGenerator0 = new NumberGenerator(0L);
            BingoCard player0 = new BingoCard(CARDSIZE, numberGenerator0);
            allCards.Add(player0);

            NumberGenerator numberGenerator1 = new NumberGenerator(1L);
            BingoCard player1 = new BingoCard(CARDSIZE, numberGenerator1);
            allCards.Add(player1);

            NumberGenerator numberGenerator2 = new NumberGenerator(2L);
            BingoCard player2 = new BingoCard(CARDSIZE, numberGenerator2);
            allCards.Add(player2);

            NumberGenerator numberGenerator3 = new NumberGenerator(3L);
            BingoCard player3 = new BingoCard(CARDSIZE, numberGenerator3);
            allCards.Add(player3);

            NumberGenerator numberGenerator4 = new NumberGenerator(4L);
            BingoCard player4 = new BingoCard(CARDSIZE, numberGenerator4);
            allCards.Add(player4);

            //Le jeu commence.

            do
            {
                newNumber = draws.Next();
                weGotWinner = Game(allCards, newNumber);
                abacus.Add(newNumber);
                nbOfDraws++;

            } while (weGotWinner == false);

            for (int i = 0; i < allCards.Count; i++)
            {
                DisplayCard(allCards[i]);
                Console.WriteLine();
            }

            winnerIndex = IsWinner(allCards);
            Console.WriteLine();
            Console.WriteLine("Tirages :" + string.Join(", ", abacus));
            Console.WriteLine();
            Console.WriteLine($"Le gagnant est le joueur: #{winnerIndex}");
            Console.WriteLine($"Nombres de trirages requis: {nbOfDraws}");
            Console.WriteLine($"Son score est de: {player3.ComputeScore(player3)}");
            Console.WriteLine();
            DisplayWinner(allCards);
        }

        public static void DisplayCard(BingoCard allCards)
        {
            for (int i = 0; i < allCards.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < allCards.Cells.GetLength(1); j++)
                {
                    if (allCards.Cells[i, j].IsCellMarked())
                    {
                        Console.Write($"{allCards.Cells[i, j]}+");
                    }
                    else
                    {
                        Console.Write($"{allCards.Cells[i, j]} ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void DisplayWinner(List<BingoCard> allCards)
        {
            int winner = IsWinner(allCards);
            DisplayCard(allCards[winner]);
        }

        public static bool Game(List<BingoCard> cards, int draw) //Le jeux continue j'usqu'a trouver un gagnant.
        {
            bool doWeGotAWinner = false;

            for (int k = 0; k < cards.Count; k++)  // K represente l'index dans la liste de BingoCard donc une carte Bingo
            {
                for (int i = 0; i < cards[k].Cells.GetLength(0); i++)
                {
                    for (int j = 0; j < cards[k].Cells.GetLength(1); j++)
                    {
                        if ((cards[k].Cells[i, j].IsCellMarked() == false) && (cards[k].Cells[i, j].CellValue == draw))      //Verifie si la cellule n'est pas deja marquée et que les nombres matches.
                        {
                            cards[k].Cells[i, j].MarkCell(draw);       //Marque la cellule si le nombre match.

                            if (RowVerification(cards[k], i) || ColVerification(cards[k], j) == true)  //Vérifie toute la ligne ou collone pour voir si il y'a un gagnant.
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return doWeGotAWinner;
        }

        public static bool RowVerification(BingoCard card, int row) //Prend la carte et verifie  une rangée
        {
            for (int col = 0; col < card.Cells.GetLength(0); col++)
            {
                if (!card.Cells[row, col].IsCellMarked())
                {
                    return false;
                }
            }

            return true;
        }
        public static bool ColVerification(BingoCard card, int col) //Prend la carte et verifie  une colonne
        {
            for (int row = 0; row < card.Cells.GetLength(0); row++)
            {
                if (!card.Cells[row, col].IsCellMarked())
                {
                    return false;
                }
            }

            return true;
        }

        public static int IsWinner(List<BingoCard> card)  //Retourne l'index de la carte gagnante.
        {
            bool weGotAwinner = false;
            int winnerIndex = -1;

            for (int i = 0; i < card.Count; i++)
            {

                for (int row = 0; row < card[i].Cells.GetLength(0); row++)
                {
                    if (RowVerification(card[i], row))       // Prend une carte bingo dans la liste de carte donnée en parametre pour verifier chaque rangée. 
                    {
                        weGotAwinner = true;
                    }
                }

                for (int col = 0; col < card[i].Cells.GetLength(0); col++)
                {
                    if (ColVerification(card[i], col))    // Prend une carte bingo dans la liste de carte donnée en parametre pour verifier chaque colonne.
                    {
                        weGotAwinner = true;
                    }
                }

                if (weGotAwinner == true)   // Dès qu'on détecte un gagnant on sort de la fonction, en retournat l'index du gagnant sinon on retourne -1.
                {
                    return winnerIndex = i;
                }
            }
            return winnerIndex;
        }
    }
}
