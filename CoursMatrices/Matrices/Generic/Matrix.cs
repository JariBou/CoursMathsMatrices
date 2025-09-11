using System.Numerics;
using CoursMatrices.Interfaces;

namespace CoursMatrices.Matrices.Generic;

public partial class Matrix<T> : IMatrix where T : INumber<T>, new()
{
    private readonly int _columnCount;
    private readonly int _rowCount;
    private readonly T[,] _matrix;
    
    public int ColumnCount => _columnCount;
    public int RowCount => _rowCount;

    public Matrix(int rowCount, int columnCount)
    {
        if (columnCount < 1 || rowCount < 1)
        {
            throw new ArgumentOutOfRangeException($"MatrixInt {nameof(rowCount)} & {nameof(columnCount)} must be stricly positive, where '{rowCount}' & '{columnCount}'.");
        }

        _columnCount = columnCount;
        _rowCount = rowCount;
        _matrix = new T[_rowCount, _columnCount];
    }

    public Matrix(T[,]  matrix)
    {
        _rowCount = matrix.GetLength(0);        
        _columnCount = matrix.GetLength(1);
        _matrix = new T[_rowCount, _columnCount];
        Array.Copy(matrix, _matrix, matrix.Length);
    }

    public Matrix(Matrix<T> target) : this(target._matrix) { }

    public T[,] ToArray2D()
    {
        return _matrix;
    }
    
    public T this[int column, int row]
    {
        get => _matrix[column, row];
        set => _matrix[column, row] = value;
    }
    
    public bool IsIdentity()
    {
        if (_columnCount != _rowCount) return false;
        return this == Identity(_columnCount);
    }
    
    public static Matrix<T> Identity(int size)
    {
        Matrix<T> matrixInt = new(size, size);
        for (int i = 0; i < size; i++)
        {
            matrixInt[i, i] = T.One;
        }
        return matrixInt;
    }

    public Matrix<T> Transpose()
    {
        return Transpose(this);
    }

    public static Matrix<T> Transpose(Matrix<T> matrix)
    {
        Matrix<T> transposedMatrix = new(matrix.ColumnCount, matrix.RowCount);

        for (int i = 0; i < matrix.RowCount; i++)
        {
            for (int j = 0; j < matrix.ColumnCount; j++)
            {
                transposedMatrix[j, i] = matrix._matrix[i, j];
            }
        }
        
        return transposedMatrix;
    }
}