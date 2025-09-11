using System.Runtime.CompilerServices;
using CoursMatrices.Interfaces;

namespace CoursMatrices.Exceptions;

public class MatrixSizeOperationException(IMatrix matrixInt, IMatrix m2, [CallerMemberName] string? operationName = "") : Exception($"Invalid Operation '{operationName}' on Matrixes of different sizes: m1[{matrixInt.RowCount}, {matrixInt.ColumnCount}] | m2[{m2.RowCount}, {m2.ColumnCount}]")
{
    
}