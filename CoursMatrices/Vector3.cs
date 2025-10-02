using System.Numerics;
using System.Runtime.CompilerServices;
using CoursMatrices.Exceptions;
using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices;

public struct Vector3(float x, float y, float z)
{
    public float x = x;
    public float y = y;
    public float z = z;
    
    public static Vector3 operator *(Matrix<float> matrix, Vector3 vector)
    {
        if (matrix.RowCount != 3) throw new MatrixSizeOperationException(matrix);

        Matrix<float> vectorMatrix = ToVectorMatrix(vector);
        Matrix<float> multiply = MatrixOperations.Multiply(matrix, vectorMatrix);
        return ToVectorMatrix(multiply);
    }

    private static Matrix<float> ToVectorMatrix(Vector3 vector)
    {
        return new Matrix<float>(new[,]{{ vector.x }, { vector.y }, { vector.z }});
    }
    
    private static Vector3 ToVectorMatrix<T>(Matrix<T> matrixSource) where T : INumber<T>, new()
    {
        if (matrixSource.RowCount != 3 || matrixSource.ColumnCount != 1) throw new MatrixSizeOperationException(matrixSource);
        Matrix<float> matrix = matrixSource.ConvertTo<float>();
        return new Vector3(matrix[0, 0], matrix[1, 0], matrix[2, 0]);
    }
    
}