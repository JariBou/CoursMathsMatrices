using System.Numerics;
using CoursMatrices.Exceptions;

namespace CoursMatrices.Matrices.Generic.Operations;

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
        return RowReduction(m1.ConvertTo<float>(), Identity<float>(m1.RowCount), true).result2;
    }
    
    public static Matrix<T> SubMatrix<T>(Matrix<T> m, int line, int column) where T : INumber<T>, new()
    {
        return m.SubMatrix(line, column);
    }

    public static float Determinant<T>(Matrix<T> matrixSource) where T : INumber<T>, new()
    {
        if (matrixSource.ColumnCount <= 0 || matrixSource.ColumnCount != matrixSource.RowCount) throw new MatrixSizeOperationException(matrixSource);

        Matrix<float> matrix = matrixSource.ConvertTo<float>();
        
        if (matrixSource.ColumnCount == 2)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }
        
        int k = 0;
        float determinant = 0f;
        for (int row = 0; row < matrix.RowCount; row++)
        {
            determinant += matrix[row, k] * Cofactor(matrix, row, k);
        }
        return determinant;
    }

    public static float Cofactor<T>(Matrix<T> matrix, int lineIndex, int columnIndex) where T : INumber<T>, new()
    {
        if (matrix.RowCount == 1)
        {
            Matrix<float> convertTo = matrix.ConvertTo<float>();
            return MathF.Pow(-1, lineIndex + columnIndex) * convertTo[0, 0];
        }
        return MathF.Pow(-1, lineIndex + columnIndex) * matrix.SubMatrix(lineIndex, columnIndex).Determinant();
    }

    public static Matrix<float> Adjugate<T>(Matrix<T> matrix) where T : INumber<T>, new()
    {
        if (matrix.ColumnCount <= 1 || matrix.ColumnCount != matrix.RowCount) throw new MatrixSizeOperationException(matrix);
        
        Matrix<float> matrixSource = matrix.ConvertTo<float>();
        Matrix<float> result = new(matrix.RowCount, matrix.ColumnCount);

        if (matrix.RowCount == 2)
        {
            result[0, 0] = matrixSource[1, 1];
            result[0, 1] = -matrixSource[0, 1];
            
            result[1, 0] = -matrixSource[1, 0];
            result[1, 1] = matrixSource[0, 0];
            
            return result;
        }
        
        for (int i = 0; i < matrixSource.RowCount; i++)
        {
            for (int j = 0; j < matrixSource.ColumnCount; j++)
            {
                result[i, j] = Cofactor(matrix, i, j);
            }
        }

        return result.Transpose();
    }

    public static Matrix<float> InvertByDeterminant<T>(Matrix<T> matrix) where T : INumber<T>, new()
    {
        if (Determinant(matrix) == 0f){throw new MatrixInvertException(matrix);}
        return 1 / Determinant(matrix) * Adjugate(matrix);
    }
}