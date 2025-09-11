using System.Runtime.CompilerServices;
using CoursMatrices.Interfaces;

namespace CoursMatrices.Exceptions;

public sealed class MatrixSizeOperationException : Exception
{
    public MatrixSizeOperationException(IMatrix matrixInt, IMatrix m2, [CallerMemberName] string? operationName = "") : base($"Invalid Operation '{operationName}' on Matrixes of different sizes: m1[{matrixInt.RowCount}, {matrixInt.ColumnCount}] | m2[{m2.RowCount}, {m2.ColumnCount}]")
    {
    }
    
    public MatrixSizeOperationException(IMatrix matrixInt, [CallerMemberName] string? operationName = "") : base($"Invalid Operation '{operationName}' on Matrix of size: (rowCount, columnCount)[{matrixInt.RowCount}, {matrixInt.ColumnCount}]")
    {
    }
}