namespace StrippedMatrixAlgorithm;

public class StripedAlgorithm : IAlgorithm
{
    protected int[][] matrixA;
    protected int[][] matrixB;

    public StripedAlgorithm(int[][] matrixA, int[][] matrixB)
    {
        this.matrixA = matrixA;
        this.matrixB = matrixB;
    }

    public virtual int[][] Multiply()
    {
        var rowsA = matrixA.Length;
        var colsA = matrixA[0].Length;
        var colsB = matrixB[0].Length;

        var result = InitializeResultMatrix(rowsA, colsB);

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                var sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += matrixA[i][k] * matrixB[k][j];
                }
                result[i][j] = sum;
            }
        }

        return result;
    }

    protected int[][] InitializeResultMatrix(int rows, int cols)
    {
        var result = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            result[i] = new int[cols];
        }
        return result;
    }
}