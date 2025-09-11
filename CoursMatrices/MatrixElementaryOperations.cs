using CoursMatrices.Exceptions;
using CoursMatrices.Matrices;

namespace CoursMatrices;

public class MatrixIntElementaryOperations
{
    public static void SwapLines(MatrixInt matrix, int l1, int l2)
    {
        int[] line1 = matrix.GetRow(l1);
        int[] line2 = matrix.GetRow(l2);
        
        matrix.SetRow(l1, line2);
        matrix.SetRow(l2, line1);
    }

    public static void SwapColumns(MatrixInt matrix, int c1, int c2)
    {
        int[] column1 = matrix.GetColumn(c1);
        int[] column2 = matrix.GetColumn(c2);
        
        matrix.SetColumn(c1, column2);
        matrix.SetColumn(c2, column1);
    }

    public static void MultiplyLine(MatrixInt matrix, int l1, int scalar)
    {
        if (scalar == 0)
        {
            throw new MatrixScalarZeroException();
        }
        
        int[] line1 = matrix.GetRow(l1);
        for (int i = 0; i < line1.Length; i++)
        {
            line1[i] *= scalar;
        }
        matrix.SetRow(l1, line1);
    }
    
    public static void MultiplyColumn(MatrixInt matrix, int c1, int scalar)
    {
        if (scalar == 0)
        {
            throw new MatrixScalarZeroException();
        }

        int[] column1 = matrix.GetColumn(c1);
        for (int i = 0; i < column1.Length; i++)
        {
            column1[i] *= scalar;
        }
        matrix.SetColumn(c1, column1);
    }

    public static void AddLineToAnother(MatrixInt matrix, int sourceLine, int targetLine, int multiplier)
    {
        int[] source = matrix.GetRow(sourceLine);
        int[] targetValue = matrix.GetRow(targetLine);

        for (int i = 0; i < source.Length; i++)
        {
            targetValue[i] += source[i] * multiplier;
        }
        
        matrix.SetRow(targetLine, targetValue);
    }

    public static void AddColumnToAnother(MatrixInt matrix, int sourceColumn, int targetColumn, int multiplier)
    {
        int[] source = matrix.GetColumn(sourceColumn);
        int[] targetValue = matrix.GetColumn(targetColumn);

        for (int i = 0; i < source.Length; i++)
        {
            targetValue[i] += source[i] * multiplier;
        }
        
        matrix.SetColumn(targetColumn, targetValue);
    }
}