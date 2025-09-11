using System.Numerics;
using CoursMatrices.Exceptions;

namespace CoursMatrices.Matrices.Generic;

public class MatrixElementaryOperations
{
    public static void SwapLines<T>(Matrix<T> matrix, int l1, int l2) where T : INumber<T>, new()
    {
        T[] line1 = matrix.GetRow(l1);
        T[] line2 = matrix.GetRow(l2);
        
        matrix.SetRow(l1, line2);
        matrix.SetRow(l2, line1);
    }

    public static void SwapColumns<T>(Matrix<T> matrix, int c1, int c2) where T : INumber<T>, new()
    {
        T[] column1 = matrix.GetColumn(c1);
        T[] column2 = matrix.GetColumn(c2);
        
        matrix.SetColumn(c1, column2);
        matrix.SetColumn(c2, column1);
    }

    public static void MultiplyLine<T, TScalar>(Matrix<T> matrix, int l1, TScalar scalar) where T : INumber<T>, new() where TScalar : INumber<TScalar>
    {
        if (scalar == TScalar.Zero)
        {
            throw new MatrixScalarZeroException();
        }
        
        T[] line1 = matrix.GetRow(l1);
        for (int i = 0; i < line1.Length; i++)
        {
            line1[i] *= T.CreateChecked(scalar);
        }
        matrix.SetRow(l1, line1);
    }
    
    public static void MultiplyColumn<T, TScalar>(Matrix<T> matrix, int c1, TScalar scalar) where T : INumber<T>, new() where TScalar : INumber<TScalar>
    {
        if (scalar == TScalar.Zero)
        {
            throw new MatrixScalarZeroException();
        }

        T[] column1 = matrix.GetColumn(c1);
        for (int i = 0; i < column1.Length; i++)
        {
            column1[i] *= T.CreateChecked(scalar);
        }
        matrix.SetColumn(c1, column1);
    }

    public static void AddLineToAnother<T, TScalar>(Matrix<T> matrix, int sourceLine, int targetLine, TScalar multiplier) where T : INumber<T>, new() where TScalar : INumber<TScalar>
    {
        T[] source = matrix.GetRow(sourceLine);
        T[] targetValue = matrix.GetRow(targetLine);

        for (int i = 0; i < source.Length; i++)
        {
            targetValue[i] += source[i] * T.CreateChecked(multiplier);
        }
        
        matrix.SetRow(targetLine, targetValue);
    }

    public static void AddColumnToAnother<T, TScalar>(Matrix<T> matrix, int sourceColumn, int targetColumn, TScalar multiplier) where T : INumber<T>, new() where TScalar : INumber<TScalar>
    {
        T[] source = matrix.GetColumn(sourceColumn);
        T[] targetValue = matrix.GetColumn(targetColumn);

        for (int i = 0; i < source.Length; i++)
        {
            targetValue[i] += source[i] * T.CreateChecked(multiplier);
        }
        
        matrix.SetColumn(targetColumn, targetValue);
    }
}