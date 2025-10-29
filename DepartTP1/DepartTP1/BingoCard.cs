using SolutionTP1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DepartTP1
{
    public class BingoCard
    {
        private CardCell[,] cell;
        private int nbDrawedNumbers;
        public BingoCard(int cardSize, NumberGenerator number)
        {
            if(number == null)
            {
                throw new ArgumentNullException("La carte doit  avoir un generateur de nombre");

            }

            if(cardSize <= 0)
            {
                cardSize = 5;
            }
            int nbOfLines = cardSize;
            int nbOfCol = cardSize;

            Cells = new CardCell[nbOfLines, nbOfCol];

            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {

                    Cells[i, j] = new CardCell(number.Next());
                }
            }
        }


        public CardCell[,] Cells
        {
            get => cell;

            private set
            {
                cell = value;
            }
        }

        public int NbDrawedNumbers
        {
            get => nbDrawedNumbers;
            set => nbDrawedNumbers = value;

        }

        public void MarkNumber(int number)
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {

                    if (this.Cells[i, j].CellValue == number)
                    {
                        this.Cells[i, j].IsMarked = true;
                        this.NbDrawedNumbers++;
                        return;             //Pour arreter quand le nombre a été trouvé et marqué.
                    }
                }
            }
        }

        public long ComputeScore(BingoCard card)  // La valeur de chaque cellule est de type longue, donc le retour est de type longue.
        {
            long score = 0;

            for (int i = 0; i < this.Cells.GetLength(0); i++)
            {
                for (int j = 0; j < this.Cells.GetLength(1); j++)
                {

                    if (Program.RowVerification(card, i) == true)  // Verifie si la rangée est gagnante
                    {
                        score = ComputeWinningRowScore(card, i);  // Si la rangée est gagnante alors nous avons son index, donc nous pouvons la passer en parametre pour calculer le score de cette rangée.
                    }
                    else if (Program.ColVerification(card, j) == true)
                    {
                        score = ComputeWinningColScore(card, j);

                    }
                }
            }
            return score;
        }


        public static long ComputeWinningRowScore(BingoCard card, int row)  
        {
            long score = 0;
            bool isWinnerRow = Program.RowVerification(card, row);     //Reverifie si la rangée est bien gagnante.
            if (isWinnerRow == true)
            {
                for (int col = 0; col < card.Cells.GetLength(1); col++)
                {

                    if (card.Cells[row, col].IsMarked)      // Nous avons l'index de la rangée gagnante en parametre donc nous pouvons calculer le score de celle-ci
                    {
                        score += card.Cells[row, col].CellValue;
                    }
                }
            }

            return score;
        }

        public static long ComputeWinningColScore(BingoCard card, int col)    //J'aurais pu combiner ComputeWinningColScore et ComputeWinningRowScore en une methode mais je me suis dit plus je le divise
        {                                                                    //plus c'est facile a lire.
            long score = 0;
            bool isWinnerCol = Program.ColVerification(card, col);
            if (isWinnerCol == true)
            {
                for (int row = 0; row < card.Cells.GetLength(0); row++)
                {

                    if (card.Cells[row, col].IsMarked)
                    {
                        score += card.Cells[row, col].CellValue;
                    }
                }
            }

            return score;
        }
    }
}
