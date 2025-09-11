using CoursMatrices.Exceptions;
using CoursMatrices.Interfaces;

namespace CoursMatrices.Matrices;

public partial class MatrixInt : IMatrix
{
    private readonly int _columnCount;
    private readonly int _rowCount;
    private readonly int[,] _matrix;
    
    public int ColumnCount => _columnCount;
    public int RowCount => _rowCount;
    public int[,] Matrix => _matrix;

    public MatrixInt(int rowCount, int columnCount)
    {
        if (columnCount < 1 || rowCount < 1)
        {
            throw new ArgumentOutOfRangeException($"MatrixInt {nameof(rowCount)} & {nameof(columnCount)} must be stricly positive, where '{rowCount}' & '{columnCount}'.");
        }

        _columnCount = columnCount;
        _rowCount = rowCount;
        _matrix = new int[_rowCount, _columnCount];
    }

    public MatrixInt(int[,]  matrix)
    {
        _rowCount = matrix.GetLength(0);        
        _columnCount = matrix.GetLength(1);
        _matrix = new int[_rowCount, _columnCount];
        Array.Copy(matrix, _matrix, matrix.Length);
    }

    public MatrixInt(MatrixInt target) : this(target._matrix)
    {
    }

    public int[,] ToArray2D()
    {
        return _matrix;
    }
    
    public bool IsIdentity()
    {
        if (_columnCount != _rowCount) return false;
        return this == Identity(_columnCount);
    }
    
    public static MatrixInt Identity(int size)
    {
        MatrixInt matrixInt = new(size, size);
        for (int i = 0; i < size; i++)
        {
            matrixInt[i, i] = 1;
        }
        return matrixInt;
    }

    public MatrixInt Transpose()
    {
        return Transpose(this);
    }

    public static MatrixInt Transpose(MatrixInt matrix)
    {
        MatrixInt transposedMatrix = new(matrix.ColumnCount, matrix.RowCount);

        for (int i = 0; i < matrix.RowCount; i++)
        {
            for (int j = 0; j < matrix.ColumnCount; j++)
            {
                transposedMatrix[j, i] = matrix._matrix[i, j];
            }
        }
        
        return transposedMatrix;
    }

    public int[] GetRow(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= RowCount)
        {
            throw new ArgumentOutOfRangeException(nameof(rowIndex));
        }
        
        int[] row = new int[ColumnCount];
        for (int i = 0; i < ColumnCount; i++)
        {
            row[i] = this[rowIndex, i];
        }
        
        return row;
    }
    
    public void SetRow(int rowIndex, int[] values)
    {
        if (rowIndex < 0 || rowIndex >= RowCount)
        {
            throw new ArgumentOutOfRangeException(nameof(rowIndex));
        }

        if (values.Length < ColumnCount)
        {
            throw new Exception($"Expected array of size {ColumnCount} but got {values.Length}.");
        }
        
        for (int i = 0; i < ColumnCount; i++)
        {
            this[rowIndex, i] = values[i];
        }
    }
    
    public int[] GetColumn(int columnIndex)
    {
        if (columnIndex < 0 || columnIndex >= ColumnCount)
        {
            throw new ArgumentOutOfRangeException(nameof(columnIndex));
        }
        
        int[] column = new int[RowCount];
        for (int i = 0; i < RowCount; i++)
        {
            column[i] = this[i, columnIndex];
        }
        
        return column;
    }
    
    public void SetColumn(int columnIndex, int[] values)
    {
        if (columnIndex < 0 || columnIndex >= ColumnCount)
        {
            throw new ArgumentOutOfRangeException(nameof(columnIndex));
        }
        
        if (values.Length < RowCount)
        {
            throw new Exception($"Expected array of size {RowCount} but got {values.Length}.");
        }
        
        for (int i = 0; i < RowCount; i++)
        {
            this[i, columnIndex] = values[i];
        }
    }

    public static MatrixInt GenerateAugmentedMatrix(MatrixInt m1, MatrixInt m2)
    {
        if (m1.RowCount != m2.RowCount || m2._columnCount != 1) throw new MatrixSizeOperationException(m1, m2);
        MatrixInt augmentedMatrix = new(m1.RowCount, m1.ColumnCount+1);
        for (int i = 0; i < m1.ColumnCount; i++)
        {
            augmentedMatrix.SetColumn(i, m1.GetColumn(i));
        }
        augmentedMatrix.SetColumn(augmentedMatrix.ColumnCount-1, m2.GetColumn(0));
        
        return augmentedMatrix;
    }

    public (MatrixInt m1, MatrixInt m2) Split(int splitInclusiveIndex)
    {
        if (splitInclusiveIndex < 0 || splitInclusiveIndex >= ColumnCount) throw new ArgumentOutOfRangeException(nameof(splitInclusiveIndex));
        int splitValue = splitInclusiveIndex+1;
        MatrixInt result1 = new(RowCount, splitValue);
        MatrixInt result2 = new(RowCount, ColumnCount- splitValue);

        for (int i = 0; i <= splitInclusiveIndex; i++)
        {
            result1.SetColumn(i, GetColumn(i));
        }

        for (int i = splitValue; i < ColumnCount; i++)
        {
            result2.SetColumn(i - splitValue, GetColumn(i));
        }
        
        return (result1, result2);
    }
}