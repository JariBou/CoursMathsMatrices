using System.Numerics;
using System.Runtime.CompilerServices;
using CoursMatrices.Exceptions;
using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices;

public struct Vector4(float x, float y, float z, float w)
{
    public float x = x;
    public float y = y;
    public float z = z;
    public float w = w;
    
    public static Vector4 operator *(Matrix<float> matrix, Vector4 vector)
    {
        if (matrix.RowCount != 4) throw new MatrixSizeOperationException(matrix);

        Matrix<float> vectorMatrix = ToVectorMatrix(vector);
        Matrix<float> multiply = MatrixOperations.Multiply(matrix, vectorMatrix);
        return ToVectorMatrix(multiply);
    }

    private static Matrix<float> ToVectorMatrix(Vector4 vector)
    {
        return new Matrix<float>(new[,]{{ vector.x }, { vector.y }, { vector.z }, { vector.w }});
    }
    
    private static Vector4 ToVectorMatrix<T>(Matrix<T> matrixSource) where T : INumber<T>, new()
    {
        if (matrixSource.RowCount != 4 || matrixSource.ColumnCount != 1) throw new MatrixSizeOperationException(matrixSource);
        Matrix<float> matrix = matrixSource.ConvertTo<float>();
        return new Vector4(matrix[0, 0], matrix[1, 0], matrix[2, 0], matrix[3, 0]);
    }
    
}