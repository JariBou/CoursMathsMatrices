using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices.Tests.TestsGenericMatrices
{
    [TestFixture]
    public class Tests12_SubMatricesGeneric
    {
        [Test]
        public void TestGetSubMatricesInstance()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 6f, 8f, 9f },
                { 17f, 0f, 1f },
                { 23f, 4f, 1f }
            });

            Matrix<float> subMatrix_0_0 = m.SubMatrix(0, 0);
            Assert.That(new[,]
            {
                { 0f, 1f },
                { 4f, 1f },
            }, Is.EqualTo(subMatrix_0_0.ToArray2D()));

            Matrix<float> subMatrix_0_1 = m.SubMatrix(0, 1);
            Assert.That(new[,]
            {
                { 17f, 1f },
                { 23f, 1f },
            }, Is.EqualTo(subMatrix_0_1.ToArray2D()));

            Matrix<float> subMatrix_0_2 = m.SubMatrix(0, 2);
            Assert.That(new[,]
            {
                { 17f, 0f },
                { 23f, 4f },
            }, Is.EqualTo(subMatrix_0_2.ToArray2D()));

            Matrix<float> subMatrix_1_0 = m.SubMatrix(1, 0);
            Assert.That(new[,]
            {
                { 8f, 9f },
                { 4f, 1f },
            }, Is.EqualTo(subMatrix_1_0.ToArray2D()));

            Matrix<float> subMatrix_1_1 = m.SubMatrix(1, 1);
            Assert.That(new[,]
            {
                { 6f, 9f },
                { 23f, 1f },
            }, Is.EqualTo(subMatrix_1_1.ToArray2D()));

            Matrix<float> subMatrix_1_2 = m.SubMatrix(1, 2);
            Assert.That(new[,]
            {
                { 6f, 8f },
                { 23f, 4f },
            }, Is.EqualTo(subMatrix_1_2.ToArray2D()));

            Matrix<float> subMatrix_2_0 = m.SubMatrix(2, 0);
            Assert.That(new[,]
            {
                { 8f, 9f },
                { 0f, 1f },
            }, Is.EqualTo(subMatrix_2_0.ToArray2D()));

            Matrix<float> subMatrix_2_1 = m.SubMatrix(2, 1);
            Assert.That(new[,]
            {
                { 6f, 9f },
                { 17f, 1f },
            }, Is.EqualTo(subMatrix_2_1.ToArray2D()));

            Matrix<float> subMatrix_2_2 = m.SubMatrix(2, 2);
            Assert.That(new[,]
            {
                { 6f, 8f },
                { 17f, 0f },
            }, Is.EqualTo(subMatrix_2_2.ToArray2D()));
        }

        [Test]
        public void TestGetSubMatricesStatic()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 2f, 3f },
                { 4f, 5f, 6f },
                { 7f, 8f, 9f }
            });

            Matrix<float> subMatrix_0_0 = MatrixOperations.SubMatrix(m, 0, 0);
            Assert.That(new[,]
            {
                { 5f, 6f },
                { 8f, 9f },
            }, Is.EqualTo(subMatrix_0_0.ToArray2D()));
            
            Matrix<float> subMatrix_1_2 = MatrixOperations.SubMatrix(m, 1, 0);
            Assert.That(new[,]
            {
                { 2f, 3f },
                { 8f, 9f },
            }, Is.EqualTo(subMatrix_1_2.ToArray2D()));
            
            Matrix<float> subMatrix_2_1 = MatrixOperations.SubMatrix(m, 2, 1);
            Assert.That(new[,]
            {
                { 1f, 3f },
                { 4f, 6f },
            }, Is.EqualTo(subMatrix_2_1.ToArray2D()));
            
            Matrix<float> subMatrix_0_2 = MatrixOperations.SubMatrix(m, 0, 2);
            Assert.That(new[,]
            {
                { 4f, 5f },
                { 7f, 8f },
            }, Is.EqualTo(subMatrix_0_2.ToArray2D()));
        }
    }
}