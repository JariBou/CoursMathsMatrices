using System.Numerics;

namespace CoursMatrices.Matrices.Generic;

public static partial class MatrixOperations
{
    public static (Matrix<float> result1, Matrix<float> result2) RowReduction(Matrix<float> m1, Matrix<float> m2)
    {
        Matrix<float> result = GenerateAugmentedMatrix(m1, m2);

        int i = 0;
        for (int j = 0; j < m1.ColumnCount; j++)
        {
            int k = 0;
            double? max = null;
    
            for (int row = i; row < m1.RowCount; row++)
            {
                if ((max == null && result[row, j] != 0f) || (max != null && result[row, j] > max))
                {
                    max = result[row, j];
                    k = row;
                }
            }

            if (max is null) break;
            
            if (k != i)
            {
                for (int column = j; column < result.ColumnCount; column++)
                {
                    (result[i, column], result[k, column]) = (result[k, column], result[j, column]);
                }
            }
        
            float scalar = 1f/result[i, j];
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
}