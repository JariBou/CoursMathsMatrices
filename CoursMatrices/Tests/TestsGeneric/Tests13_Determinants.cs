using CoursMatrices.Matrices.Generic;

namespace CoursMatrices.Tests.TestsGeneric
{
    [TestFixture]
    public class Tests13_DeterminantsGeneric
    {
        [Test, DefaultFloatingPointTolerance(0.001f)]
        public void TestDeterminantMatrix2x2()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 2f },
                { 3f, 4f }
            });

            float determinant = MatrixOperations.Determinant(m);

            Assert.That(determinant, Is.EqualTo(-2f));
        }

        [Test]
        public void TestDeterminantMatrix3x3()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 2f, 3f },
                { 4f, 5f, 6f },
                { 7f, 8f, 9f },
            });

            float determinant = MatrixOperations.Determinant(m);

            Assert.That(determinant, Is.EqualTo(0f));
        }
        
        [Test]
        public void TestDeterminantMatrix4x4()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 0.707f, 2.449f, 4.243f, 1.000f },
                { 0.707f, 2.449f, -4.243f, 2.000f },
                { -1.732f, 2.000f, 0.000f, 3.000f },
                { 0.000f, 0.000f, 0.000f, 1.000f },
            });

            float determinant = MatrixOperations.Determinant(m);

            Assert.That(determinant, Is.EqualTo(48f));
        }
        
        [Test]
        public void TestDeterminantIdentityMatrices()
        {
            //Identity 2
            Matrix<float> identity2 = Matrix<float>.Identity(2);
            float determinantIdentity2 = MatrixOperations.Determinant(identity2);
            Assert.That(determinantIdentity2, Is.EqualTo(1f));
            
            //Identity 3
            Matrix<float> identity3 = Matrix<float>.Identity(3);
            float determinantIdentity3 = MatrixOperations.Determinant(identity3);
            Assert.That(determinantIdentity3, Is.EqualTo(1f));
            
            //Identity 10
            Matrix<float> identity10 = Matrix<float>.Identity(10);
            float determinantIdentity10 = MatrixOperations.Determinant(identity10);
            Assert.That(determinantIdentity10, Is.EqualTo(1f));
        }
    }
}