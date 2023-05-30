using System.Diagnostics;
using StrippedMatrixAlgorithm;
using static System.Console;

const int matrixSize = 2000;
var matrixA = MatrixUtils.GenerateRandomMatrix(matrixSize, matrixSize);
var matrixB = MatrixUtils.GenerateRandomMatrix(matrixSize, matrixSize);

var watch = new Stopwatch();

var parallel = new ParallelStripedAlgorithm(matrixA, matrixB);
var algorithm = new StripedAlgorithm(matrixA, matrixB);

watch.Start();
algorithm.Multiply();
watch.Stop();
var normalElapsed = watch.ElapsedMilliseconds;
WriteLine("Elapsed: " + normalElapsed + "ms");

watch.Reset();

watch.Start();
parallel.Multiply();
watch.Stop();
var parallelElapsed = watch.ElapsedMilliseconds;
WriteLine("Parallel Elapsed: " + parallelElapsed + "ms");

WriteLine("Speedup: " + (double)normalElapsed / parallelElapsed);
 