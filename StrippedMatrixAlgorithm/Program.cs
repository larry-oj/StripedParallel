using StrippedMatrixAlgorithm;
using System.Diagnostics;
using static System.Console;

var watch = new Stopwatch();
var matrixSizes = new[] {500, 1000, 1500, 2000, 2500, 3000};

foreach (var size in matrixSizes)
{
    var matrixA = MatrixUtils.GenerateRandomMatrix(size, size);
    var matrixB = MatrixUtils.GenerateRandomMatrix(size, size);

    WriteLine("\n\nSize: " + size + "x" + size);

    var normalElapsedAvg = 0;
    int[][] normalRes = Array.Empty<int[]>();
    for (int j = 0; j < 4; j++)
    {
        var algorithm = new StripedAlgorithm(matrixA, matrixB);
        // normal
        watch.Start();
        normalRes = algorithm.Multiply();
        watch.Stop();
        normalElapsedAvg += (int)watch.ElapsedMilliseconds;
    }

    normalElapsedAvg = normalElapsedAvg / 4;

    WriteLine("Normal Elapsed: " + normalElapsedAvg + "ms");

    watch.Reset();

    for (int i = 4; i <= 8; i += 2)
    {
        WriteLine("== Threads: " + i + " ==");
        var parallelElapsedAvg = 0;
        var correct = true;
        for (int j = 0; j < 4; j++)
        {
            var parallel = new ParallelStripedAlgorithm(matrixA, matrixB, i);
            
            watch.Start();
            var parallelRes = parallel.Multiply();
            watch.Stop();
            parallelElapsedAvg += (int)watch.ElapsedMilliseconds;

            if (!MatrixUtils.CompareMatrices(normalRes, parallelRes))
            {
                WriteLine("ERROR! Parralel calculations are incorrect!");
                correct = false;
                break;
            }
        }

        parallelElapsedAvg = parallelElapsedAvg / 4;
        
        WriteLine("Parallel Elapsed: " + parallelElapsedAvg + "ms");

        WriteLine("Speedup: " + (double)normalElapsedAvg / parallelElapsedAvg);
        WriteLine("Results are equal: " + correct);
        watch.Reset();
    }
}


