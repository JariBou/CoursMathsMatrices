using System.Numerics;

namespace CoursMatrices.Matrices.Generic;

public class MatrixRowReductionAlgorithm
{
    public static (Matrix<float> result1, Matrix<float> result2) Apply(Matrix<float> m1, Matrix<float> m2) /*where T : INumber<T>, new()*/
    {
        // throw new NotImplementedException();

        Matrix<float> result = MatrixOperations.GenerateAugmentedMatrix(m1, m2);

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
                // MatrixElementaryOperations.SwapLines(result, k, i);
                // MatrixElementaryOperations.SwapLines(m2, k, i);
            }
        
            float scalar = 1f/result[i, j];
            for (int column = j; column < result.ColumnCount; column++)
            {
                result[i, column] *= scalar;
            }
            // MatrixElementaryOperations.MultiplyLine(result, i, scalar);
            // MatrixElementaryOperations.MultiplyLine(m2, i, scalar);
        
            for (int row = 0; row < m1.RowCount; row++)
            {
                if (row == i) continue;
                float cache = result[row, j];
                for (int column = j; column < result.ColumnCount; column++)
                {
                    result[row, column] += result[i, column] * -1 *cache;
                }
                // MatrixElementaryOperations.AddLineToAnother(result, i, row, -1*result[row, j]);
                // MatrixElementaryOperations.AddLineToAnother(m2, i, row, -1*m1[row, j]);
            }

            i++;
        }
        
        return result.Split(m1.ColumnCount-1);
    }
}