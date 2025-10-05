using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices.Matrices.Generic;

public partial class  Matrix<T>
{
    private bool Equals(Matrix<T> other)
    {
        if (ColumnCount != other.ColumnCount || RowCount != other.RowCount) return false;

        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                if  (_matrix[i, j] != other[i, j]) return false;
            }
        }
        
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        
        return Equals((Matrix<T>)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ColumnCount, RowCount, _matrix);
    }

    public static Matrix<T> operator *(Matrix<T> a, T scalar)
    {
        return MatrixOperations.Multiply(a, scalar);
    } 
    
    public static Matrix<T> operator *(T scalar, Matrix<T> a)
    {
        return MatrixOperations.Multiply(a, scalar);
    }
    
    public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
    {
        return MatrixOperations.Multiply(a, b);
    }
    
    public static bool operator ==(Matrix<T> a, Matrix<T> b)
    {
        if (a.ColumnCount != b.ColumnCount || a.RowCount != b.RowCount) return false;

        for (int i = 0; i < a.RowCount; i++)
        {
            for (int j = 0; j < a.ColumnCount; j++)
            {
                if  (a[i, j] != b[i, j]) return false;
            }
        }
        
        return true;
    }

    public static bool operator !=(Matrix<T> a, Matrix<T> b)
    {
        return !(a == b);
    }

    public static Matrix<T> operator -(Matrix<T> a)
    {
        return MatrixOperations.Multiply(a, -T.One);
    }
    
    public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
    {
        return MatrixOperations.Add(a, b);
    }
    
    public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
    {
        return MatrixOperations.Add(a, -b);
    }
}