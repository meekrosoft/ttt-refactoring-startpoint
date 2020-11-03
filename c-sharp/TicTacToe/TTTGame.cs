namespace TicTacToe
{
    public class TTTGame
    {
        private int lstMv;

        private int[,] cells = new int[3, 3];

        public bool isOver()
        {
            return Winner() != 0;
        }

        // 0 undecided
        // 1 circle
        // 2 cross
        // 3 draw
        private int Winner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (cells[0, i] == cells[1, i]
                    && cells[0, i] == cells[2, i]
                    && cells[0, i] != 0)
                    return cells[0, i];
                if (cells[i, 0] == cells[i, 1]
                    && cells[i, 0] == cells[i, 2]
                    && cells[i, 0] != 0)
                    return cells[i, 0];
            }

            if (cells[0, 0] == cells[1, 1]
                && cells[0, 0] == cells[2, 2]
                && cells[0, 0] != 0)
                return cells[0, 0];

            if (cells[2, 0] == cells[1, 1]
                && cells[2, 0] == cells[0, 2]
                && cells[2, 0] != 0)
                return cells[2, 0];

            bool bEmpty = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cells[j, i] == 0)
                    {
                        bEmpty = true;
                    }
                }
            }

            return bEmpty ? 0 : 3;
        }

        public void makeMove(int i, int i1)
        {
            if (cells[i, i1] == 1) throw new TicTacException();

            cells[i, i1] = 1;
        }

        public void placeCircle(int i, int i1)
        {
            if (isOver() || (lstMv == 1) || (cells[i, i1] != 0))
            {
                throw new TicTacException();
            }
            else
            {
                cells[i, i1] = 1;
                lstMv = 1;
            }
        }

        public void placeCross(int i, int i1)
        {
            if (lstMv == 2) throw new TicTacException();

            if (cells[i, i1] != 0) throw new TicTacException();

            cells[i, i1] = 2;

            lstMv = 2;
        }

        public int winner()
        {
            return Winner();
        }
    }
}
