using System.Runtime.CompilerServices;
using CoursMatrices.Interfaces;

namespace CoursMatrices.Exceptions;

public sealed class MatrixInvertException : Exception 
{
    public MatrixInvertException(IMatrix matrixInt, [CallerMemberName] string? operationName = "") : base($"Error while trying to invert Matrix of size: (rowCount, columnCount)[{matrixInt.RowCount}, {matrixInt.ColumnCount}] in '{operationName}'")
    {
    }
    
    public MatrixInvertException([CallerMemberName] string? operationName = "") : base($"Error while trying to invert matrix in '{operationName}'")
    {
    }
}