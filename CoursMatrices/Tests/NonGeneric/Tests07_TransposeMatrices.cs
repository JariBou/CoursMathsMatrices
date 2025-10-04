using CoursMatrices.Matrices;

namespace CoursMatrices.Tests.NonGeneric
{
    [TestFixture]
    public class Tests07TransposeMatrices
    {
        [Test]
        public void TestTransposeMatrixInstance()
        {
            MatrixInt m1 = new(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            });

            MatrixInt m1T = m1.Transpose();

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
            MatrixInt m1 = new(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            });

            MatrixInt m1T = MatrixInt.Transpose(m1);

            Assert.That(new[,]
            {
                { 1, 4 },
                { 2, 5 },
                { 3, 6 }
            }, Is.EqualTo(m1T.ToArray2D()));
        }
    }
}