namespace CoursMatrices.Matrices;

public partial class MatrixInt
{
    protected bool Equals(MatrixInt other)
    {
        return _columnCount == other._columnCount && _rowCount == other._rowCount && _matrix.Equals(other._matrix);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((MatrixInt)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_columnCount, _rowCount, _matrix);
    }

    public int this[int row, int column]
    {
        get => _matrix[row, column];
        set => _matrix[row, column] = value;
    }

    public static MatrixInt operator *(MatrixInt a, int scalar)
    {
        return Multiply(a, scalar);
    }
    
    public static MatrixInt operator *(int scalar, MatrixInt a)
    {
        return Multiply(a, scalar);
    }
    
    public static MatrixInt operator *(MatrixInt a, MatrixInt b)
    {
        return Multiply(a, b);
    }
    
    public static bool operator ==(MatrixInt a, MatrixInt b)
    {
        if ((a.ColumnCount != b.ColumnCount) || (a.RowCount != b.RowCount)) return false;

        for (int i = 0; i < a.RowCount; i++)
        {
            for (int j = 0; j < a.ColumnCount; j++)
            {
                if  (a[i, j] != b[i, j]) return false;
            }
        }
        
        return true;
    }

    public static bool operator !=(MatrixInt a, MatrixInt b)
    {
        return !(a == b);
    }

    public static MatrixInt operator -(MatrixInt a)
    {
        return Multiply(a, -1);
    }
    
    public static MatrixInt operator +(MatrixInt a, MatrixInt b)
    {
        return Add(a, b);
    }
    
    public static MatrixInt operator -(MatrixInt a, MatrixInt b)
    {
        return Add(a, -b);
    }
}