using CoursMatrices.Exceptions;

namespace CoursMatrices.Matrices;

public partial class MatrixInt
{
    
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
    
    public MatrixInt Multiply(MatrixInt m2)
    {
        return Multiply(this, m2);
    }

    public MatrixInt Add(MatrixInt m2)
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

    public static MatrixInt Multiply(MatrixInt matrix, int scalar)
    {
        return new MatrixInt(matrix).Multiply(scalar);
    }
    
    public static MatrixInt Multiply(MatrixInt matrix, MatrixInt matrix2)
    {
        if (matrix.ColumnCount != matrix2.RowCount)
        {
            throw new MatrixSizeOperationException(matrix, matrix2);
        }

        MatrixInt result = new(matrix.RowCount, matrix2.ColumnCount);

        for (int i = 0; i < result.RowCount; i++)
        {
            for (int j = 0; j < result.ColumnCount; j++)
            {
                int sum = 0;
                for (int k = 0; k < matrix.ColumnCount; k++)
                {
                    sum += matrix[i, k] * matrix2[k, j];
                }
                result[i, j] = sum;
            }
        }
        
        return result;
    }
    
    public static MatrixInt Add(MatrixInt m1, MatrixInt m2)
    {
        return new MatrixInt(m1).Add(m2);
    }

}