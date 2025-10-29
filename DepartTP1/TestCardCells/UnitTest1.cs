using DepartTP1;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using SolutionTP1;

namespace TestCardCells
{
    public class UnitTest1
    {
        [Fact]
        public void MakeSureThisMethodCompiles()
        {
            CardCell cell = new CardCell(7);

            long value = cell.CellValue;
            bool isMarked = cell.IsMarked;
            cell.MarkCell(7);
        }

        [Fact]
        public void ConstructorTest_FirstFivecells_InitializedCorrectly()
        {
            //Arrange
            int cardSize = 5;
            const int FIRST_CELL_VALUE_EXPECTED = 339;
            const int SECOND_CELL_VALUE_EXPECTED = 285;
            const int THIRD_CELL_VALUE_EXPECTED = 263;
            const int FOURTH_CELL_VALUE_EXPECTED = 625;
            const int FITH_CELL_VALUE_EXPECTED = 463;

            NumberGenerator numberGenerator = new NumberGenerator(5L);

            //Act
            BingoCard newCard = new BingoCard(cardSize, numberGenerator);

            //Assert

            Assert.Equal(FIRST_CELL_VALUE_EXPECTED, newCard.Cells[0, 0].CellValue);
            Assert.Equal(SECOND_CELL_VALUE_EXPECTED, newCard.Cells[0, 1].CellValue);
            Assert.Equal(THIRD_CELL_VALUE_EXPECTED, newCard.Cells[0, 2].CellValue);
            Assert.Equal(FOURTH_CELL_VALUE_EXPECTED, newCard.Cells[0, 3].CellValue);
            Assert.Equal(FITH_CELL_VALUE_EXPECTED, newCard.Cells[0, 4].CellValue);

        }

        [Fact]
        public void ConstructorTest_LowSizeCard_InitializesCellsCorrectly()
        {
            //Arrange
            int cardSize = 3;
            const int FIRST_CELL_VALUE_EXPECTED = 339;
            const int SECOND_CELL_VALUE_EXPECTED = 285;
            const int THIRD_CELL_VALUE_EXPECTED = 263;
            const int LAST_CELL_VALUE_EXPECTED = 596;

            NumberGenerator numberGenerator1 = new NumberGenerator(5L);

            //Act
            BingoCard newCard = new BingoCard(cardSize, numberGenerator1);

            //Assert

            Assert.Equal(FIRST_CELL_VALUE_EXPECTED, newCard.Cells[0, 0].CellValue);
            Assert.Equal(SECOND_CELL_VALUE_EXPECTED, newCard.Cells[0, 1].CellValue);
            Assert.Equal(THIRD_CELL_VALUE_EXPECTED, newCard.Cells[0, 2].CellValue);
            Assert.Equal(LAST_CELL_VALUE_EXPECTED, newCard.Cells[2, 2].CellValue);
        }

        [Fact]
        public void ConstructorTest_LargeSizeCard_InitializesCellsCorrectly()
        {
            //Arrange
            int cardSize = 10;
            const int FIRST_CELL_VALUE_EXPECTED = 339;
            const int SECOND_CELL_VALUE_EXPECTED = 285;
            const int THIRD_CELL_VALUE_EXPECTED = 263;
            const int FOURTH_CELL_VALUE_EXPECTED = 625;
            const int FITH_CELL_VALUE_EXPECTED = 463;
            const int SIXTH_CELL_VALUE_EXPECTED = 928;
            const int SEVENTH_CELL_VALUE_EXPECTED = 147;
            const int HEIGTH_CELL_VALUE_EXPECTED = 950;
            const int NINTH_CELL_VALUE_EXPECTED = 596;
            const int TENTH_CELL_VALUE_EXPECTED = 118;


            NumberGenerator numberGenerator1 = new NumberGenerator(5L);

            //Act
            BingoCard player1 = new BingoCard(cardSize, numberGenerator1);

            //Assert

            Assert.Equal(FIRST_CELL_VALUE_EXPECTED, player1.Cells[0, 0].CellValue);
            Assert.Equal(SECOND_CELL_VALUE_EXPECTED, player1.Cells[0, 1].CellValue);
            Assert.Equal(THIRD_CELL_VALUE_EXPECTED, player1.Cells[0, 2].CellValue);
            Assert.Equal(FOURTH_CELL_VALUE_EXPECTED, player1.Cells[0, 3].CellValue);
            Assert.Equal(FITH_CELL_VALUE_EXPECTED, player1.Cells[0, 4].CellValue);
            Assert.Equal(SIXTH_CELL_VALUE_EXPECTED, player1.Cells[0, 5].CellValue);
            Assert.Equal(SEVENTH_CELL_VALUE_EXPECTED, player1.Cells[0, 6].CellValue);
            Assert.Equal(HEIGTH_CELL_VALUE_EXPECTED, player1.Cells[0, 7].CellValue);
            Assert.Equal(NINTH_CELL_VALUE_EXPECTED, player1.Cells[0, 8].CellValue);
            Assert.Equal(TENTH_CELL_VALUE_EXPECTED, player1.Cells[0, 9].CellValue);
        }

   
        [Fact]
        public void MarkCellTEST_WrongNumber_CellNotMarked()
        {
            //Arrange
            bool isCellMarked = false;
            const bool EXPECTED = false;
            const long CELL_NB = 463;
            const long NB_TO_MARK = 603;
            CardCell newCardCell = new CardCell(CELL_NB);

            //Act

            newCardCell.MarkCell(NB_TO_MARK);
            isCellMarked = newCardCell.IsCellMarked();

            //Assert
            Assert.Equal(EXPECTED, isCellMarked);

        }

     
        [Fact]
        public void MAarkCellTest_Null_NBGenarator()
        {
            //Arrange
            bool isCellMarked = false;
            const bool EXPECTED = false;
            const int CARD_SIZE = 0;
            const int NB_TO_MARK = 463;
            NumberGenerator numberGenerator1 = null;

            //Act

            Assert.Throws<ArgumentNullException>(() => new BingoCard(CARD_SIZE, numberGenerator1));

            //Assert

        }
    }
}