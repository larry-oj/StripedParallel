namespace StrippedMatrixAlgorithm;

public sealed class ParallelStripedAlgorithm : IAlgorithm
{
    private int[][] matrixA;
    private int[][] matrixB;
    private int numThreads;

    public ParallelStripedAlgorithm(int[][] matrixA, int[][] matrixB, int numThreads = 4)
    {
        this.matrixA = matrixA;
        this.matrixB = matrixB;
        this.numThreads = numThreads;
    }

    public int[][] Multiply()
    {
        var rowsA = matrixA.Length;
        var colsB = matrixB[0].Length;

        var result = InitializeResultMatrix(rowsA, colsB);
        
        var blockSize = rowsA / numThreads;
        
        if (numThreads > Environment.ProcessorCount)
            numThreads = Environment.ProcessorCount;

        var waitEvents = new ManualResetEvent[numThreads];

        for (int t = 0; t < numThreads; t++)
        {
            var startRow = t * blockSize;
            var endRow = (t == numThreads - 1) ? rowsA : (startRow + blockSize);

            waitEvents[t] = new ManualResetEvent(false);

            ThreadPool.QueueUserWorkItem(state =>
            {
                MultiplyStriped(startRow, endRow, result);
                waitEvents[(int)state!].Set();
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
    
    private int[][] InitializeResultMatrix(int rows, int cols)
    {
        var result = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            result[i] = new int[cols];
        }
        return result;
    }
}