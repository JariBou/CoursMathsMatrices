using System.Numerics;
using CoursMatrices.Exceptions;

namespace CoursMatrices.Matrices.Generic;

public static partial class MatrixOperations
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
    
    public static Matrix<T> GenerateAugmentedMatrix<T>(Matrix<T> m1, Matrix<T> m2) where T : INumber<T>, new()
    {
        if (m1.RowCount != m2.RowCount) throw new MatrixSizeOperationException(m1, m2);
        Matrix<T> augmentedMatrix = new(m1.RowCount, m1.ColumnCount+m2.ColumnCount);
        for (int i = 0; i < m1.ColumnCount; i++)
        {
            augmentedMatrix.SetColumn(i, m1.GetColumn(i));
        }

        for (int i = 0; i < m2.ColumnCount; i++)
        {
            augmentedMatrix.SetColumn(m1.ColumnCount + i, m2.GetColumn(i));
        }
        
        return augmentedMatrix;
    }
    
    public static Matrix<float> InvertByRowReduction<T>(Matrix<T> m1) where T : INumber<T>, new()
    {
        Matrix<float> result = GenerateAugmentedMatrix(m1.ConvertTo<float>(), Matrix<float>.Identity(m1.RowCount));

        int i = 0;
        for (int j = 0; j < m1.ColumnCount; j++)
        {
            int k = 0;
            double? max = null;
    
            for (int row = i; row < m1.RowCount; row++)
            {
                if ((max == null && result[row, j] != 0f) || (max != null && result[row, j] > max))
                {
                    max = result[row, j];
                    k = row;
                }
            }

            if (max is null) throw new MatrixInvertException(); 
            
            if (k != i)
            {
                for (int column = j; column < result.ColumnCount; column++)
                {
                    (result[i, column], result[k, column]) = (result[k, column], result[j, column]);
                }
            }
        
            float scalar = 1f/result[i, j];
            for (int column = j; column < result.ColumnCount; column++)
            {
                result[i, column] *= scalar;
            }
        
            for (int row = 0; row < m1.RowCount; row++)
            {
                if (row == i) continue;
                float cache = result[row, j];
                for (int column = j; column < result.ColumnCount; column++)
                {
                    result[row, column] += result[i, column] * -1 *cache;
                }
            }

            i++;
        }
        
        return result.Split(m1.ColumnCount-1).m2;
    }
    
    public static Matrix<T> SubMatrix<T>(Matrix<T> m, int line, int column) where T : INumber<T>, new()
    {
        return m.SubMatrix(line, column);
    }

    public static float Determinant<T>(Matrix<T> matrixSource) where T : INumber<T>, new()
    {
        if (matrixSource.ColumnCount <= 0 || matrixSource.ColumnCount != matrixSource.RowCount) throw new MatrixSizeOperationException(matrixSource);

        Matrix<float> matrix = matrixSource.ConvertTo<float>();
        
        int k = 1;
        float determinant = 0f;
        for (int row = 0; row < matrix.ColumnCount; row++)
        {
            determinant += matrix[row, k] * Cofactor(matrix, row, k);
        }
        return determinant;
    }

    public static float Cofactor<T>(Matrix<T> matrix, int lineIndex, int columnIndex) where T : INumber<T>, new()
    {
        return MathF.Pow(-1, lineIndex + columnIndex) * matrix.SubMatrix(lineIndex, columnIndex).Determinant();
    }
}