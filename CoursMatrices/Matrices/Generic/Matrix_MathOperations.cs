using System.Numerics;
using CoursMatrices.Exceptions;

namespace CoursMatrices.Matrices.Generic;

public partial class Matrix<T>
{
    public Matrix<T> Multiply<TScalar>(TScalar scalar) where TScalar : INumber<TScalar>
    {
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                this[i, j] *= T.CreateChecked(scalar);
            }
        }
        
        return this;
    }
    
    public Matrix<T> Multiply(Matrix<T> m2)
    {
        return MatrixOperations.Multiply(this, m2);
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

    public Matrix<float> InvertByRowReduction()
    {
        return MatrixOperations.InvertByRowReduction(this);
    }

    public float Determinant()
    {
        return MatrixOperations.Determinant(this);
    }
}