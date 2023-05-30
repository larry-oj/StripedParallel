using System.Diagnostics;
using StrippedMatrixAlgorithm;
using static System.Console;

const int matrixSize = 1000;
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
// WriteLine("-------------------------------------");
//  
// matrixA = MatrixUtils.GenerateRandomMatrix(1000, 1000);
// matrixB = MatrixUtils.GenerateRandomMatrix(1000, 1000);
//
// watch = new Stopwatch();
//
// parallel = new ParallelStripedAlgorithm(matrixA, matrixB);
// algorithm = new StripedAlgorithm(matrixA, matrixB);
//
// watch.Start();
// algorithm.Multiply();
// watch.Stop();
// normalElapsed = watch.ElapsedMilliseconds;
// WriteLine("Elapsed: " + normalElapsed + "ms");
//
// watch.Reset();
//
// watch.Start();
// parallel.Multiply();
// watch.Stop();
// parallelElapsed = watch.ElapsedMilliseconds;
// WriteLine("Parallel Elapsed: " + parallelElapsed + "ms");
//
// WriteLine("Speedup: " + (double)normalElapsed / parallelElapsed);
// WriteLine("-------------------------------------");
//
// matrixA = MatrixUtils.GenerateRandomMatrix(1500, 1500);
// matrixB = MatrixUtils.GenerateRandomMatrix(1500, 1500);
//
// watch = new Stopwatch();
//
// parallel = new ParallelStripedAlgorithm(matrixA, matrixB);
// algorithm = new StripedAlgorithm(matrixA, matrixB);
//
// watch.Start();
// algorithm.Multiply();
// watch.Stop();
// normalElapsed = watch.ElapsedMilliseconds;
// WriteLine("Elapsed: " + normalElapsed + "ms");
//
// watch.Reset();
//
// watch.Start();
// parallel.Multiply();
// watch.Stop();
// parallelElapsed = watch.ElapsedMilliseconds;
// WriteLine("Parallel Elapsed: " + parallelElapsed + "ms");
//
// WriteLine("Speedup: " + (double)normalElapsed / parallelElapsed);
// WriteLine("-------------------------------------");
//
// matrixA = MatrixUtils.GenerateRandomMatrix(2000, 2000);
// matrixB = MatrixUtils.GenerateRandomMatrix(2000, 2000);
//
// watch = new Stopwatch();
//
// parallel = new ParallelStripedAlgorithm(matrixA, matrixB);
// algorithm = new StripedAlgorithm(matrixA, matrixB);
//
// watch.Start();
// algorithm.Multiply();
// watch.Stop();
// normalElapsed = watch.ElapsedMilliseconds;
// WriteLine("Elapsed: " + normalElapsed + "ms");
//
// watch.Reset();
//
// watch.Start();
// parallel.Multiply();
// watch.Stop();
// parallelElapsed = watch.ElapsedMilliseconds;
// WriteLine("Parallel Elapsed: " + parallelElapsed + "ms");
//
// WriteLine("Speedup: " + (double)normalElapsed / parallelElapsed);
// WriteLine("-------------------------------------");
//
// matrixA = MatrixUtils.GenerateRandomMatrix(3000, 3000);
// matrixB = MatrixUtils.GenerateRandomMatrix(3000, 3000);
//
// watch = new Stopwatch();
//
// parallel = new ParallelStripedAlgorithm(matrixA, matrixB);
// algorithm = new StripedAlgorithm(matrixA, matrixB);
//
// watch.Start();
// algorithm.Multiply();
// watch.Stop();
// normalElapsed = watch.ElapsedMilliseconds;
// WriteLine("Elapsed: " + normalElapsed + "ms");
//
// watch.Reset();
//
// watch.Start();
// parallel.Multiply();
// watch.Stop();
// parallelElapsed = watch.ElapsedMilliseconds;
// WriteLine("Parallel Elapsed: " + parallelElapsed + "ms");
//
// WriteLine("Speedup: " + (double)normalElapsed / parallelElapsed);
// WriteLine("-------------------------------------");


/*
Elapsed: 882ms
Parallel Elapsed: 203ms
Speedup: 4.344827586206897
-------------------------------------
Elapsed: 7961ms
Parallel Elapsed: 1844ms
Speedup: 4.3172451193058565
-------------------------------------
Elapsed: 30600ms
Parallel Elapsed: 7586ms
Speedup: 4.033746374901134
-------------------------------------
Elapsed: 84337ms
Parallel Elapsed: 21070ms
Speedup: 4.002705268153773
-------------------------------------
Elapsed: 346831ms
Parallel Elapsed: 112520ms
Speedup: 3.082394241023818
-------------------------------------

*/