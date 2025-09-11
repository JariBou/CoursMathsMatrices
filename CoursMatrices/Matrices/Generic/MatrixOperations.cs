using System.Numerics;
using CoursMatrices.Exceptions;

namespace CoursMatrices.Matrices.Generic;

public static class MatrixOperations
{
    public static Matrix<T> Identity<T>(int size) where T : INumber<T>, new()
    {
        Matrix<T> matrixInt = new(size, size);
        for (int i = 0; i < size; i++)
        {
            matrixInt[i, i] = T.One;
        }
        return matrixInt;
    }
    
    public static Matrix<T> Add<T>(Matrix<T> m1, Matrix<T> m2) where T : INumber<T>, new()
    {
        return new Matrix<T>(m1).Add(m2);
    }

    public static Matrix<T> Multiply<T, TScalar>(Matrix<T> matrix, TScalar scalar) where TScalar : INumber<TScalar> where T : INumber<T>, new()
    {
        return new Matrix<T>(matrix).Multiply(scalar);
    }
    
    public static Matrix<T> Multiply<T>(Matrix<T> matrix, Matrix<T> matrix2) where T : INumber<T>, new()
    {
        if (matrix.ColumnCount != matrix2.RowCount)
        {
            throw new MatrixSizeOperationException(matrix, matrix2);
        }

        Matrix<T> result = new Matrix<T>(matrix.RowCount, matrix2.ColumnCount);

        for (int i = 0; i < result.RowCount; i++)
        {
            for (int j = 0; j < result.ColumnCount; j++)
            {
                T sum = new();
                for (int k = 0; k < matrix.ColumnCount; k++)
                {
                    sum += matrix[i, k] * matrix2[k, j];
                }
                result[i, j] = sum;
            }
        }
        
        return result;
    }
}