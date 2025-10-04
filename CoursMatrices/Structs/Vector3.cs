using System.Numerics;
using CoursMatrices.Exceptions;
using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices.Structs;

public struct Vector3(float x, float y, float z)
{
    public static readonly Vector3 XAxis = new(1, 0, 0);
    public static readonly Vector3 YAxis = new(0, 1, 0);
    public static readonly Vector3 ZAxis = new(0, 0, 1);
    
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

    public static implicit operator Vector3(Vector4 vector)
    {
        return new Vector3(vector.x, vector.y, vector.z);
    }
    
    public static Vector3 operator /(Vector3 vector, float number)
    {
        return new Vector3(vector.x/number, vector.y/number, vector.z/number);
    }
    
    public static Vector3 operator *(Vector3 vector, float number)
    {
        return new Vector3(vector.x*number, vector.y*number, vector.z*number);
    }


    public Vector3 Normalize()
    {
        return this / Magnitude;
    }

    public float Magnitude => MathF.Sqrt(x*x + y*y + z*z);
}