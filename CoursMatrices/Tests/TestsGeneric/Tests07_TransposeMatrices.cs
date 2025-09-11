using CoursMatrices.Matrices;
using CoursMatrices.Matrices.Generic;

namespace CoursMatrices.TestsGeneric
{
    [TestFixture]
    public class Tests07_TransposeMatricesGeneric
    {
        [Test]
        public void TestTransposeMatrixInstance()
        {
            Matrix<int> m1 = new Matrix<int>(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            });

            Matrix<int> m1t = m1.Transpose();

            Assert.That(new[,]
            {
                { 1, 4 },
                { 2, 5 },
                { 3, 6 }
            }, Is.EqualTo(m1t.ToArray2D()));
        }
        
        [Test]
        public void TestTransposeMatrixStatic()
        {
            Matrix<int> m1 = new Matrix<int>(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            });

            Matrix<int> m1t = Matrix<int>.Transpose(m1);

            Assert.That(new[,]
            {
                { 1, 4 },
                { 2, 5 },
                { 3, 6 }
            }, Is.EqualTo(m1t.ToArray2D()));
        }
    }
}