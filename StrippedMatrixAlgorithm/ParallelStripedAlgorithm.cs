namespace StrippedMatrixAlgorithm;

public sealed class ParallelStripedAlgorithm : StripedAlgorithm
{
    public ParallelStripedAlgorithm(int[][] matrixA, int[][] matrixB)
        : base(matrixA, matrixB)
    {
    }

     public override int[][] Multiply()
    {
        var rowsA = matrixA.Length;
        var colsA = matrixA[0].Length;
        var colsB = matrixB[0].Length;

        var result = InitializeResultMatrix(rowsA, colsB);

        var numThreads = Environment.ProcessorCount;
        var blockSize = rowsA / numThreads;

        var waitEvents = new ManualResetEvent[numThreads];

        for (int t = 0; t < numThreads; t++)
        {
            var startRow = t * blockSize;
            var endRow = (t == numThreads - 1) ? rowsA : (startRow + blockSize);

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
        var colsA = matrixA[0].Length;
        var colsB = matrixB[0].Length;

        for (int i = startRow; i < endRow; i++)
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
    }
}