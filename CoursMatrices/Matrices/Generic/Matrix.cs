using System.Numerics;
using CoursMatrices.Exceptions;
using CoursMatrices.Interfaces;

namespace CoursMatrices.Matrices.Generic;

public partial class Matrix<T> : IMatrix where T : INumber<T>, new()
{
    private readonly T[,] _matrix;
    
    public int ColumnCount { get; }

    public int RowCount { get; }

    public Matrix(int rowCount, int columnCount)
    {
        if (columnCount < 1 || rowCount < 1)
        {
            throw new ArgumentOutOfRangeException($"Matrix's {nameof(rowCount)} & {nameof(columnCount)} must be stricly positive, where '{rowCount}' & '{columnCount}'.");
        }

        ColumnCount = columnCount;
        RowCount = rowCount;
        _matrix = new T[RowCount, ColumnCount];
    }

    public Matrix(T[,]  matrix)
    {
        RowCount = matrix.GetLength(0);        
        ColumnCount = matrix.GetLength(1);
        _matrix = new T[RowCount, ColumnCount];
        Array.Copy(matrix, _matrix, matrix.Length);
    }

    public Matrix(Matrix<T> target) : this(target._matrix) { }

    public Matrix<TTarget> ConvertTo<TTarget>() where TTarget : INumber<TTarget>, new()
    {
        Matrix<TTarget> result =  new Matrix<TTarget>(RowCount, ColumnCount);
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                result[i, j] = TTarget.CreateChecked(_matrix[i, j]);
            }
        }
        return result;
    }

    public T[,] ToArray2D()
    {
        return _matrix;
    }
    
    public T this[int row, int column]
    {
        get => _matrix[row, column];
        set => _matrix[row, column] = value;
    }
    
    public bool IsIdentity()
    {
        return ColumnCount == RowCount && this == Identity(ColumnCount);
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
        Matrix<T> transposedMatrix = new(ColumnCount, RowCount);

        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                transposedMatrix[j, i] = this[i, j];
            }
        }
        
        return transposedMatrix;
    }

    public T[] GetRow(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= RowCount)
        {
            throw new ArgumentOutOfRangeException(nameof(rowIndex));
        }
        
        T[] row = new T[ColumnCount];
        for (int i = 0; i < ColumnCount; i++)
        {
            row[i] = this[rowIndex, i];
        }
        
        return row;
    }
    
    public void SetRow(int rowIndex, T[] values)
    {
        if (rowIndex < 0 || rowIndex >= RowCount)
        {
            throw new ArgumentOutOfRangeException(nameof(rowIndex));
        }

        if (values.Length < ColumnCount)
        {
            throw new Exception($"Expected array of size {ColumnCount} but was {values.Length}.");
        }
        
        for (int i = 0; i < ColumnCount; i++)
        {
            this[rowIndex, i] = values[i];
        }
    }
    
    public T[] GetColumn(int columnIndex)
    {
        if (columnIndex < 0 || columnIndex >= ColumnCount)
        {
            throw new ArgumentOutOfRangeException(nameof(columnIndex));
        }
        
        T[] column = new T[RowCount];
        for (int i = 0; i < RowCount; i++)
        {
            column[i] = this[i, columnIndex];
        }
        
        return column;
    }
    
    public void SetColumn(int columnIndex, T[] values)
    {
        if (columnIndex < 0 || columnIndex >= ColumnCount)
        {
            throw new ArgumentOutOfRangeException(nameof(columnIndex));
        }
        
        if (values.Length < RowCount)
        {
            throw new Exception($"Expected array of size {RowCount} was {values.Length}.");
        }
        
        for (int i = 0; i < RowCount; i++)
        {
            this[i, columnIndex] = values[i];
        }
    }

    public (Matrix<T> m1, Matrix<T> m2) Split(int splitIndex)
    {
        if (splitIndex < 0 || splitIndex >= ColumnCount) throw new ArgumentOutOfRangeException(nameof(splitIndex));
        int splitValue = splitIndex+1;
        Matrix<T> result1 = new(RowCount, splitValue);
        Matrix<T> result2 = new(RowCount, ColumnCount- splitValue);

        for (int i = 0; i <= splitIndex; i++)
        {
            result1.SetColumn(i, GetColumn(i));
        }

        for (int i = splitValue; i < ColumnCount; i++)
        {
            result2.SetColumn(i - splitValue, GetColumn(i));
        }
        
        return (result1, result2);
    }

    public Matrix<T> SubMatrix(int line, int column)
    {
        if (line > RowCount || column > ColumnCount || RowCount <= 1 || ColumnCount <= 1)
        {
            throw new MatrixSizeOperationException(this);
        }
        
        var matrix = new Matrix<T>(RowCount-1, ColumnCount-1);
        int rowIndex = 0;
        for (int i = 0; i < RowCount; i++)
        {
            if (i == line) continue;
            int columnIndex = 0;
            for (int j = 0; j < ColumnCount; j++)
            {
                if (j == column) continue;
                
                matrix[rowIndex, columnIndex] = this[i, j];
                
                columnIndex++;
            }
            rowIndex++;
        }
        
        return matrix;
    }
}