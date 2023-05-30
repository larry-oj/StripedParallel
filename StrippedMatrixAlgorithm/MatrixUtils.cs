namespace StrippedMatrixAlgorithm;

public class MatrixUtils
{
    // generate random matrix with a given size
    public static int[][] GenerateRandomMatrix(int rows, int cols)
    {
        var matrix = new int[rows][];

        var random = new Random();

        for (int i = 0; i < rows; i++)
        {
            matrix[i] = new int[cols];
            for (int j = 0; j < cols; j++)
            {
                matrix[i][j] = random.Next(100);
            }
        }

        return matrix;
    }
    
    // print matrix
    public static void PrintMatrix(int[][] matrix)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write(matrix[i][j] + " ");
            Console.WriteLine();
        }
    }
    
    // compare two matrices
    public static bool CompareMatrices(int[][] matrixA, int[][] matrixB)
    {
        var rowsA = matrixA.Length;
        var colsA = matrixA[0].Length;
        var rowsB = matrixB.Length;
        var colsB = matrixB[0].Length;

        if (rowsA != rowsB || colsA != colsB)
            return false;

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsA; j++)
            {
                if (matrixA[i][j] != matrixB[i][j])
                    return false;
            }
        }

        return true;
    }
}