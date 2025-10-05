using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices.Tests.TestsGenericMatrices
{
    [TestFixture]
    public class Tests07TransposeMatricesGeneric
    {
        [Test]
        public void TestTransposeMatrixInstance()
        {
            Matrix<int> m1 = new Matrix<int>(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            });

            Matrix<int> m1T = m1.Transpose();

            Assert.That(new[,]
            {
                { 1, 4 },
                { 2, 5 },
                { 3, 6 }
            }, Is.EqualTo(m1T.ToArray2D()));
        }
        
        [Test]
        public void TestTransposeMatrixStatic()
        {
            Matrix<int> m1 = new Matrix<int>(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            });

            Matrix<int> m1T = MatrixOperations.Transpose(m1);

            Assert.That(new[,]
            {
                { 1, 4 },
                { 2, 5 },
                { 3, 6 }
            }, Is.EqualTo(m1T.ToArray2D()));
        }
    }
}