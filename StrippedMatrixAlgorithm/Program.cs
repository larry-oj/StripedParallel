using System.Diagnostics;
using StrippedMatrixAlgorithm;
using static System.Console;

var watch = new Stopwatch();
var matrixSizes = new[] {500, 1000, 1500, 2000, 2500, 3000};

foreach (var size in matrixSizes)
{
    var matrixA = MatrixUtils.GenerateRandomMatrix(size, size);
    var matrixB = MatrixUtils.GenerateRandomMatrix(size, size);
    
    var algorithm = new StripedAlgorithm(matrixA, matrixB);
    var parallel = new ParallelStripedAlgorithm(matrixA, matrixB, 8);
    
    WriteLine("\n\nSize: " + size + "x" + size);
    
    // normal
    watch.Start();
    var normalRes = algorithm.Multiply();
    watch.Stop();
    var normalElapsed = watch.ElapsedMilliseconds;
    WriteLine("Normal Elapsed: " + normalElapsed + "ms");

    watch.Reset();

    // parallel
    watch.Start();
    var parallelRes = parallel.Multiply();
    watch.Stop();
    var parallelElapsed = watch.ElapsedMilliseconds;
    WriteLine("Parallel Elapsed: " + parallelElapsed + "ms");

    WriteLine("Speedup: " + (double)normalElapsed / parallelElapsed);

    WriteLine("Results are equal: " + MatrixUtils.CompareMatrices(normalRes, parallelRes));
    
    watch.Reset();
}