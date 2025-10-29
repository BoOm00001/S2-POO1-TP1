using DepartTP1;
using SolutionTP1;
using static DepartTP1.BingoCard;

namespace TestBingoCard
{
    public class UnitTest1
    {
        [Fact]
        public void MakeSureThisMethodCompiles()
        {
            NumberGenerator generator = new NumberGenerator();
            BingoCard card = new BingoCard(5, generator);
            card.MarkNumber(3);
            long score = card.ComputeScore(card);
        }

        [Fact]
        public void ComputeScoreTestt_WinningRow()
        {
            //Arrange
            bool isMarked = true;
            long score = 0;
            const int CARD_SIZE = 5;
            const int EXPECTED = 1975;
            const int FIRST_NB_TO_MARK = 339;
            const int SECOND_NB_TO_MARK = 285;
            const int THIRD_NB_TO_MARK = 263;
            const int FOURTH_NB_TO_MARK = 625;
            const int FIFTH_NB_TO_MARK = 463;
          
            NumberGenerator numberGenerator1 = new NumberGenerator(5L);
            BingoCard bingoCard = new BingoCard(CARD_SIZE, numberGenerator1);

            //Act

            bingoCard.Cells[0, 0].MarkCell(FIRST_NB_TO_MARK);
            bingoCard.Cells[0, 1].MarkCell(SECOND_NB_TO_MARK);
            bingoCard.Cells[0, 2].MarkCell(THIRD_NB_TO_MARK);
            bingoCard.Cells[0, 3].MarkCell(FOURTH_NB_TO_MARK);
            bingoCard.Cells[0, 4].MarkCell(FIFTH_NB_TO_MARK);
            score = bingoCard.ComputeScore(bingoCard);

            //Assert

            Assert.Equal(EXPECTED, score);


        }

        [Fact]
        public void ComputeScoreTest_WinningCol()
        {
            //Arrange
            bool isMarked = true;
            long score = 0;
            const int FIRST_NB_TO_MARK = 339;
            const int SECOND_NB_TO_MARK = 928;
            const int THIRD_NB_TO_MARK = 975;
            const int FOURTH_NB_TO_MARK = 153;
            const int FIFTH_NB_TO_MARK = 481;
            const int CARD_SIZE = 5;
            const int EXPECTED = 2876;

            NumberGenerator numberGenerator1 = new NumberGenerator(5L);
            BingoCard bingoCard = new BingoCard(CARD_SIZE, numberGenerator1);

            //Act
            bingoCard.Cells[0, 0].MarkCell(FIRST_NB_TO_MARK);
            bingoCard.Cells[1, 0].MarkCell(SECOND_NB_TO_MARK);
            bingoCard.Cells[2, 0].MarkCell(THIRD_NB_TO_MARK);
            bingoCard.Cells[3, 0].MarkCell(FOURTH_NB_TO_MARK);
            bingoCard.Cells[4, 0].MarkCell(FIFTH_NB_TO_MARK);
            score = bingoCard.ComputeScore(bingoCard);

            //Assert

            Assert.Equal(EXPECTED, score);
        }

        [Fact]
        public void ComputeScoreText_NoWinningCard()
        {
            //Arrange
            bool isMarked = true;
            long score = 0;
            const int FIRST_NB_TO_MARK = 339;
            const int SECOND_NB_TO_MARK = 28;
            const int THIRD_NB_TO_MARK = 95;
            const int FOURTH_NB_TO_MARK = 15;
            const int FIFTH_NB_TO_MARK = 481;
            const int CARD_SIZE = 5;
            const int EXPECTED = 0;

            NumberGenerator numberGenerator1 = new NumberGenerator(5L);
            BingoCard bingoCard = new BingoCard(CARD_SIZE, numberGenerator1);

            //Act
            bingoCard.Cells[0, 0].MarkCell(FIRST_NB_TO_MARK);
            bingoCard.Cells[1, 0].MarkCell(SECOND_NB_TO_MARK);
            bingoCard.Cells[2, 0].MarkCell(THIRD_NB_TO_MARK);
            bingoCard.Cells[3, 0].MarkCell(FOURTH_NB_TO_MARK);
            bingoCard.Cells[4, 0].MarkCell(FIFTH_NB_TO_MARK);
            score = bingoCard.ComputeScore(bingoCard);

            //Assert

            Assert.Equal(EXPECTED, score);


        }
    }
}