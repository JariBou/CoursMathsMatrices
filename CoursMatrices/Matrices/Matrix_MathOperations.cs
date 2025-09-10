using System.Numerics;
using CoursMatrices.Exceptions;

namespace CoursMatrices.Matrices;

public partial class  Matrix<T>
{
    
    public Matrix<T> Multiply(T scalar)
    {
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                this[i, j] *= scalar;
            }
        }
        
        return this;
    }
    
    public Matrix<T> Multiply(Matrix<T> m2)
    {
        return Multiply(this, m2);
    }

    public Matrix<T> Add(Matrix<T> m2)
    {
        if ((ColumnCount != m2.ColumnCount) || (RowCount != m2.RowCount))
        {
            throw new MatrixSizeOperationException(this, m2);
        }

        
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                this[i, j] += m2[i, j];;
            }
        }
        
        return this;
    }

    public static Matrix<T> Multiply(Matrix<T> matrix, T scalar)
    {
        return new Matrix<T>(matrix).Multiply(scalar);
    }
    
    public static Matrix<T> Multiply(Matrix<T> matrix, Matrix<T> matrix2)
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
    
    public static Matrix<T> Add(Matrix<T> m1, Matrix<T> m2)
    {
        return new Matrix<T>(m1).Add(m2);
    }

}