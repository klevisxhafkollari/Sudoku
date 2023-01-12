public class Program
{
    public static void Main()
    {
        int[][] sudoku =
        {
             new int[] {7,8,4,  1,5,9,  3,2,6},
             new int[] {5,3,9,  6,7,2,  8,4,1},
             new int[] {6,1,2,  4,3,8,  7,5,9},
             new int[] {9,2,8,  7,1,5,  4,6,3},
             new int[] {3,5,7,  8,4,6,  1,9,2},
             new int[] {4,6,1,  9,2,3,  5,8,7},
             new int[] {8,7,6,  3,9,4,  2,1,5},
             new int[] {2,4,3,  5,6,1,  9,7,8},
             new int[] {1,9,5,  2,8,7,  6,3,4}
        };

        Console.WriteLine(ValidateSudoku(sudoku));
    }

    public static bool ValidateSudoku(int[][] sudoku)
    {
        var length = Length(sudoku);
        if (length == 0 || !CheckSquare(length) || !CheckRows(length, sudoku) || !CheckColumns(length, sudoku) || !CheckLittleSquares(length, sudoku))
            return false;
        return true;
    }

    ///check the length of the sudoku
    public static int Length(int[][] sudoku)
    {
        if (sudoku is null || sudoku.Length == 0)
            return 0;
        return sudoku.Length;
    }

    ///check if sudoku length is square of an int(Natural) number
    public static bool CheckSquare(int length)
    {
        var square = Math.Sqrt(length);
        if (square != (int)square)
            return false;
        return true;
    }

    ///check if each value of a row is between [1-N] and they are unique
    public static bool CheckRows(int length, int[][] sudoku)
    {
        for (int i = 0; i < length; i++)
        {
            if (sudoku[i].Any(x => x < 1 || x > length) || sudoku[i].Distinct().Count() != length)
                return false;
        }
        return true;
    }

    ///check if each value of a column is between [1-N] and they are unique
    public static bool CheckColumns(int length, int[][] sudoku)
    {
        for (int j = 0; j < length; j++)
        {
            if (sudoku.Any(x => x[j] < 1 || x[j] > length) || sudoku.Select(x => x[j]).Distinct().Count() != length)
                return false;
        }
        return true;
    }

    ///check little squares 
    public static bool CheckLittleSquares(int length, int[][] sudoku)
    {
        int square = (int)Math.Sqrt(length);

        for (int i = 0; i < length; i += square)
        {
            for (int j = 0; j < length; j += square)
            {
                var query = Enumerable.Range(i, square).SelectMany(x => Enumerable.Range(j, square).Select(y => sudoku[x][y]));

                if (query.Distinct().Count() != length || query.Any(x => x < 1 || x > length))
                {
                    return false;
                }
            }
        }
        return true;
    }
}