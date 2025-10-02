using CoursMatrices.Exceptions;
using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices.Tests.TestsGenericMatrices
{
    [TestFixture, DefaultFloatingPointTolerance(0.001f)]
    public class Tests15_InvertMatricesUsingDeterminantGeneric
    {
        [Test]
        public void TestInvertMatrixInstance()
        {
            //If you need help, See => https://www.sangakoo.com/en/unit/inverse-matrix-using-determinants
            //Or you can reuse the same principle from course => https://www.wikihow.com/Find-the-Inverse-of-a-3x3-Matrix
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 2f, 3f, 8f },
                { 6f, 0f, -3f },
                { -1f, 3f, 2f },
            });

            Matrix<float> mInverted = m.InvertByDeterminant();
            Matrix<float> mInvertedRowReduction = m.InvertByExplicitRowReduction();

            Assert.Multiple(() =>
            {
                Assert.That(new[,]
                        {
                { 0.066f, 0.133f, -0.066f },
                { -0.066f, 0.088f, 0.4f },
                { 0.133f, -0.066f, -0.133f }
            }, Is.EqualTo(mInverted.ToArray2D()));

                Assert.That(mInvertedRowReduction.ToArray2D(), Is.EqualTo(mInverted.ToArray2D()));
            });
        }
        
        [Test]
        public void TestInvertMatrixStatic()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 2f },
                { 3f, 4f },
            });

            Matrix<float> mInverted = MatrixOperations.InvertByDeterminant(m);

            Assert.That(new[,]
            {
                { -2f, 1f },
                { 1.5f, -0.5f },
            }, Is.EqualTo(mInverted.ToArray2D()));
        }
        
        [Test]
        public void TestInvertImpossibleMatrix()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 2f, 3f },
                { 4f, 5f, 6f },
                { 7f, 8f, 9f },
            });

            Assert.Throws<MatrixInvertException>(() =>
            {
                Matrix<float> mInverted = m.InvertByDeterminant();
            });
        }
        
    }
}