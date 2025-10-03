using CoursMatrices.Exceptions;

namespace CoursMatrices.Matrices.Generic.Operations;

public static partial class MatrixOperations
{
    public static (Matrix<float> result1, Matrix<float> result2) ExplicitRowReduction(Matrix<float> m1, Matrix<float> m2, bool throwOnNullColumnValues = false)
    {
        Matrix<float> result = GenerateAugmentedMatrix(m1, m2);

        int i = 0;
        for (int j = 0; j < m1.ColumnCount; j++)
        {
            int k = 0;
            double? max = null;
    
            for (int row = i; row < m1.RowCount; row++)
            {
                if ((max == null || result[row, j] > max) && result[row, j] != 0f)
                {
                    max = result[row, j];
                    k = row;
                }
            }

            if (max is null)
            {
                if (throwOnNullColumnValues)
                {
                    throw new MatrixInvertException();
                }
                break;
            }
            
            if (k != i)
            {
                for (int column = j; column < result.ColumnCount; column++)
                {
                    (result[i, column], result[k, column]) = (result[k, column], result[j, column]);
                }
            }
        
            float f = result[i, j];
            if (f == 0f)
            {
                f = 1f;
            }
            float scalar = 1f/f;
            for (int column = j; column < result.ColumnCount; column++)
            {
                result[i, column] *= scalar;
            }
        
            for (int row = 0; row < m1.RowCount; row++)
            {
                if (row == i) continue;
                float cache = result[row, j];
                for (int column = j; column < result.ColumnCount; column++)
                {
                    result[row, column] += result[i, column] * -1 *cache;
                }
            }

            i++;
        }
        
        return result.Split(m1.ColumnCount-1);
    }
    
    public static (Matrix<float> result1, Matrix<float> result2) RowReduction(Matrix<float> m1, Matrix<float> m2, bool throwOnNullColumnValues = false)
    {
        Matrix<float> result = GenerateAugmentedMatrix(m1, m2);

        int i = 0;
        for (int j = 0; j < m1.ColumnCount; j++)
        {
            int k = 0;
            double? max = null;
    
            for (int row = i; row < m1.RowCount; row++)
            {
                if ((max == null || result[row, j] > max) && result[row, j] != 0f)
                {
                    max = result[row, j];
                    k = row;
                }
            }

            if (max is null)
            {
                if (throwOnNullColumnValues)
                {
                    throw new MatrixInvertException();
                }
                break;
            }
            
            if (k != i)
            {
                SwapLines(result, i, k);
            }

            float f = result[i, j];
            if (f == 0f)
            {
                f = 1f;
            }
            float scalar = 1f/f;
            MultiplyLine(result, i, scalar);
        
            for (int row = 0; row < m1.RowCount; row++)
            {
                if (row == i) continue;
                float cache = result[row, j];
                AddLineToAnother(result, i, row, -cache);
            }

            i++;
        }
        
        return result.Split(m1.ColumnCount-1);
    }
}