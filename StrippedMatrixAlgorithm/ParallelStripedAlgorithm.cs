namespace StrippedMatrixAlgorithm;

public sealed class ParallelStripedAlgorithm : StripedAlgorithm
{
    public ParallelStripedAlgorithm(int[][] matrixA, int[][] matrixB)
        : base(matrixA, matrixB)
    {
    }

     public override int[][] Multiply()
    {
        int rowsA = matrixA.Length;
        int colsA = matrixA[0].Length;
        int colsB = matrixB[0].Length;

        int[][] result = InitializeResultMatrix(rowsA, colsB);

        int numThreads = Environment.ProcessorCount;
        int blockSize = rowsA / numThreads;

        ManualResetEvent[] waitEvents = new ManualResetEvent[numThreads];

        for (int t = 0; t < numThreads; t++)
        {
            int startRow = t * blockSize;
            int endRow = (t == numThreads - 1) ? rowsA : (startRow + blockSize);

            waitEvents[t] = new ManualResetEvent(false);

            ThreadPool.QueueUserWorkItem(state =>
            {
                MultiplyStriped(startRow, endRow, result);
                waitEvents[(int)state].Set();
            }, t);
        }

        WaitHandle.WaitAll(waitEvents);

        return result;
    }

    private void MultiplyStriped(int startRow, int endRow, int[][] result)
    {
        int colsA = matrixA[0].Length;
        int colsB = matrixB[0].Length;

        for (int i = startRow; i < endRow; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                int sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += matrixA[i][k] * matrixB[k][j];
                }
                result[i][j] = sum;
            }
        }
    }
}