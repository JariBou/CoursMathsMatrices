namespace CoursMatrices;

public partial class MatrixInt
{
    private readonly int _columnCount;
    private readonly int _rowCount;
    private readonly int[,] _matrix;
    
    public int ColumnCount => _columnCount;
    public int RowCount => _rowCount;

    public MatrixInt(int columnCount, int rowCount)
    {
        if (columnCount < 1 || rowCount < 1)
        {
            throw new ArgumentOutOfRangeException($"MatrixInt {nameof(columnCount)} & {nameof(rowCount)} must be stricly positive, where '{columnCount}' & '{rowCount}'.");
        }

        _columnCount = columnCount;
        _rowCount = rowCount;
        _matrix = new int[_columnCount, _rowCount];
    }

    public MatrixInt(int[,]  matrix)
    {
        _columnCount = matrix.GetLength(0);
        _rowCount = matrix.GetLength(1);
        _matrix = new int[_columnCount, _rowCount];
        Array.Copy(matrix, _matrix, matrix.Length);
    }

    public MatrixInt(MatrixInt target) : this(target._matrix)
    {
    }

    public int[,] ToArray2D()
    {
        return _matrix;
    }

    public MatrixInt Multiply(int scalar)
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

    public bool IsIdentity()
    {
        if (_columnCount != _rowCount) return false;
        return this == Identity(_columnCount);
    }

    public static MatrixInt Multiply(MatrixInt matrix, int scalar)
    {
        return matrix.Multiply(scalar);
    }

    public static MatrixInt Identity(int size)
    {
        MatrixInt matrixInt = new MatrixInt(size, size);
        for (int i = 0; i < size; i++)
        {
            matrixInt[i, i] = 1;
        }
        return matrixInt;
    }
}