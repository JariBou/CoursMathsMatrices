using System.Runtime.CompilerServices;

namespace CoursMatrices.Exceptions;

public class MatrixScalarZeroException([CallerMemberName] string? operationName = "") : Exception($"Invalid multiplication by 0 on '{operationName}'")
{
}