using CoursMatrices.Matrices.Generic;
using CoursMatrices.Matrices.Generic.Operations;

namespace CoursMatrices.Tests.TestsGenericMatrices
{
    [TestFixture]
    public class Tests12SubMatricesGeneric
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

            Matrix<float> subMatrix00 = m.SubMatrix(0, 0);
            Assert.That(new[,]
            {
                { 0f, 1f },
                { 4f, 1f },
            }, Is.EqualTo(subMatrix00.ToArray2D()));

            Matrix<float> subMatrix01 = m.SubMatrix(0, 1);
            Assert.That(new[,]
            {
                { 17f, 1f },
                { 23f, 1f },
            }, Is.EqualTo(subMatrix01.ToArray2D()));

            Matrix<float> subMatrix02 = m.SubMatrix(0, 2);
            Assert.That(new[,]
            {
                { 17f, 0f },
                { 23f, 4f },
            }, Is.EqualTo(subMatrix02.ToArray2D()));

            Matrix<float> subMatrix10 = m.SubMatrix(1, 0);
            Assert.That(new[,]
            {
                { 8f, 9f },
                { 4f, 1f },
            }, Is.EqualTo(subMatrix10.ToArray2D()));

            Matrix<float> subMatrix11 = m.SubMatrix(1, 1);
            Assert.That(new[,]
            {
                { 6f, 9f },
                { 23f, 1f },
            }, Is.EqualTo(subMatrix11.ToArray2D()));

            Matrix<float> subMatrix12 = m.SubMatrix(1, 2);
            Assert.That(new[,]
            {
                { 6f, 8f },
                { 23f, 4f },
            }, Is.EqualTo(subMatrix12.ToArray2D()));

            Matrix<float> subMatrix20 = m.SubMatrix(2, 0);
            Assert.That(new[,]
            {
                { 8f, 9f },
                { 0f, 1f },
            }, Is.EqualTo(subMatrix20.ToArray2D()));

            Matrix<float> subMatrix21 = m.SubMatrix(2, 1);
            Assert.That(new[,]
            {
                { 6f, 9f },
                { 17f, 1f },
            }, Is.EqualTo(subMatrix21.ToArray2D()));

            Matrix<float> subMatrix22 = m.SubMatrix(2, 2);
            Assert.That(new[,]
            {
                { 6f, 8f },
                { 17f, 0f },
            }, Is.EqualTo(subMatrix22.ToArray2D()));
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

            Matrix<float> subMatrix00 = MatrixOperations.SubMatrix(m, 0, 0);
            Assert.That(new[,]
            {
                { 5f, 6f },
                { 8f, 9f },
            }, Is.EqualTo(subMatrix00.ToArray2D()));
            
            Matrix<float> subMatrix12 = MatrixOperations.SubMatrix(m, 1, 0);
            Assert.That(new[,]
            {
                { 2f, 3f },
                { 8f, 9f },
            }, Is.EqualTo(subMatrix12.ToArray2D()));
            
            Matrix<float> subMatrix21 = MatrixOperations.SubMatrix(m, 2, 1);
            Assert.That(new[,]
            {
                { 1f, 3f },
                { 4f, 6f },
            }, Is.EqualTo(subMatrix21.ToArray2D()));
            
            Matrix<float> subMatrix02 = MatrixOperations.SubMatrix(m, 0, 2);
            Assert.That(new[,]
            {
                { 4f, 5f },
                { 7f, 8f },
            }, Is.EqualTo(subMatrix02.ToArray2D()));
        }
    }
}