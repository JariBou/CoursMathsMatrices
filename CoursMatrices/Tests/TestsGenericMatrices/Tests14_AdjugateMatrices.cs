using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices.Tests.TestsGenericMatrices
{
    [TestFixture, DefaultFloatingPointTolerance(0.001f)]
    public class Tests14_AdjugateMatricesGeneric
    {
        [Test]
        public void TestCalculateAdjugateMatrixInstance()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 2f },
                { 3f, 4f }
            });

            Matrix<float> adjM = m.Adjugate();
            Assert.That(new[,]
            {
                { 4f, -2f },
                { -3f, 1f },
            }, Is.EqualTo(adjM.ToArray2D()));
        }

        [Test]
        public void TestCalculateAdjugateMatrixStatic()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 0f, 5f },
                { 2f, 1f, 6f },
                { 3f, 4f, 0f },
            });

            Matrix<float> adjM = MatrixOperations.Adjugate(m);

            Assert.That(new[,]
            {
                { -24f, 20f, -5f },
                { 18f, -15f, 4f },
                { 5f, -4f, 1f },
            }, Is.EqualTo(adjM.ToArray2D()));
        }

        [Test]
        public void TestCalculateAdjugateMatrixIdentity4x4()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });

            Matrix<float> adjM = m.Adjugate();
            Assert.That(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(adjM.ToArray2D()));
        }
    }
}