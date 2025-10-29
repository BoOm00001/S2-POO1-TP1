using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DepartTP1
{
    public class CardCell
    {
        private long cellValue;
        private bool isMarked;
        List<long> markedCells = new List<long>();

        public CardCell(long value)
        {
            this.cellValue = value;
            this.isMarked = false;
        }

        public long CellValue
        {
            get => cellValue;
            set => cellValue = value;
        }

        public override string ToString()
        {
            return string.Format("{0,4}", this.CellValue);
        }

        public bool IsMarked
        {
            get => isMarked;
            set => isMarked = value;
        }

        public void MarkCell(long nb)
        {
            bool isCellMarked = IsCellMarked();
            if (!isCellMarked && this.cellValue == nb)
            {
                markedCells.Add(nb);
                this.isMarked = true;
            }
        }

        public bool IsCellMarked()
        {
            for (int i = 0; i < markedCells.Count; i++)
            {
                if (markedCells[i] == this.CellValue)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
