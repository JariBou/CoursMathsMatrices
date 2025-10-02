using System.Numerics;
using CoursMatrices.Exceptions;
using CoursMatrices.Matrices.Generic.Operations;

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

    /// <summary>
    /// Inverts a matrix using the explicit row reduction algorithm
    /// </summary>
    /// <returns> A new matrix that is the reduction of the input matrix </returns>
    public Matrix<float> InvertByExplicitRowReduction()
    {
        return MatrixOperations.InvertByExplicitRowReduction(this);
    }
    
    /// <summary>
    /// Inverts a matrix using the row reduction algorithm
    /// </summary>
    /// <returns> A new matrix that is the reduction of the input matrix </returns>
    public Matrix<float> InvertByRowReduction()
    {
        return MatrixOperations.InvertByRowReduction(this);
    }

    public float Determinant()
    {
        return MatrixOperations.Determinant(this);
    }

    public Matrix<float> Adjugate()
    {
        return MatrixOperations.Adjugate(this);
    }

    public Matrix<float> InvertByDeterminant()
    {
        return MatrixOperations.InvertByDeterminant(this);
    }
}