using CoursMatrices.Matrices.Generic;
using CoursMatrices.Structs;

namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture, DefaultFloatingPointTolerance(0.001d)]
    public class Tests16TransformationMatrices
    {
        [Test]
        public void TestTranslatePoint()
        {
            Vector4 v = new(1f, 0f, 0f, 1f);
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 3f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            });

            Vector4 vTransformed = m * v;
            Assert.Multiple(() =>
            {
                Assert.That(vTransformed.x, Is.EqualTo(6f));
                Assert.That(vTransformed.y, Is.EqualTo(3f));
                Assert.That(vTransformed.z, Is.EqualTo(1f));
            });

            Vector4 vTransformedInverted = m.InvertByExplicitRowReduction() * vTransformed;
            Assert.Multiple(() =>
            {
                Assert.That(vTransformedInverted.x, Is.EqualTo(1f));
                Assert.That(vTransformedInverted.y, Is.EqualTo(0f));
                Assert.That(vTransformedInverted.z, Is.EqualTo(0f));
            });

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.Multiple(() =>
            {
                Assert.That(vTransformedInverted.x, Is.EqualTo(1f));
                Assert.That(vTransformedInverted.y, Is.EqualTo(0f));
                Assert.That(vTransformedInverted.z, Is.EqualTo(0f));
            });

        }
        
        [Test]
        public void TestTranslateDirection()
        {
            Vector4 v = new(1f, 0f, 0f, 0f);
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 3f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            });
            Vector4 vTransformed = m * v;

            Assert.Multiple(() =>
            {
                Assert.That(vTransformed.x, Is.EqualTo(1f));
                Assert.That(vTransformed.y, Is.EqualTo(0f));
                Assert.That(vTransformed.z, Is.EqualTo(0f));
            });

            Vector4 vTransformedInverted = m.InvertByExplicitRowReduction() * vTransformed;
            Assert.Multiple(() =>
            {
                Assert.That(vTransformedInverted.x, Is.EqualTo(1f));
                Assert.That(vTransformedInverted.y, Is.EqualTo(0f));
                Assert.That(vTransformedInverted.z, Is.EqualTo(0f));
            });

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.Multiple(() =>
            {
                Assert.That(vTransformedInverted.x, Is.EqualTo(1f));
                Assert.That(vTransformedInverted.y, Is.EqualTo(0f));
                Assert.That(vTransformedInverted.z, Is.EqualTo(0f));
            });
        }
        
        [Test]
        public void TestScalePoint()
        {
            Vector4 v = new(2f, 1f, 3f, 1f);
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 0.5f, 0f, 0f, 0f },
                { 0.0f, 2f, 0f, 0f },
                { 0.0f, 0f, 3f, 0f },
                { 0.0f, 0f, 0f, 1f },
            });
        
            Vector4 vTransformed = m * v;
            Assert.Multiple(() =>
            {
                Assert.That(vTransformed.x, Is.EqualTo(1f));
                Assert.That(vTransformed.y, Is.EqualTo(2f));
                Assert.That(vTransformed.z, Is.EqualTo(9f));
            });

            Vector4 vTransformedInverted = m.InvertByExplicitRowReduction() * vTransformed;
            Assert.Multiple(() =>
            {
                Assert.That(vTransformedInverted.x, Is.EqualTo(2f));
                Assert.That(vTransformedInverted.y, Is.EqualTo(1f));
                Assert.That(vTransformedInverted.z, Is.EqualTo(3f));
            });

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.Multiple(() =>
            {
                Assert.That(vTransformedInverted.x, Is.EqualTo(2f));
                Assert.That(vTransformedInverted.y, Is.EqualTo(1f));
                Assert.That(vTransformedInverted.z, Is.EqualTo(3f));
            });
        }
        
        [Test]
        public void TestRotatePoint()
        {
            Vector4 v = new(1f, 4f, 7f, 1f);
            double a = Math.PI / 2d;
            float cosA = (float)Math.Cos(a);
            float sinA = (float)Math.Sin(a);
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { cosA, -sinA, 0f, 0f },
                { sinA, cosA, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });
        
            Vector4 vTransformed = m * v;
            Assert.Multiple(() =>
            {
                Assert.That(vTransformed.x, Is.EqualTo(-4f));
                Assert.That(vTransformed.y, Is.EqualTo(1f));
                Assert.That(vTransformed.z, Is.EqualTo(7f));
            });

            Matrix<float> invertByRowReduction = m.InvertByRowReduction();
            Matrix<float> invertByDeterminant = m.InvertByDeterminant();
            Vector4 vTransformedInverted = invertByRowReduction * vTransformed;
            
            Assert.Multiple(() =>
            {
                //Assert.That(invertByRowReduction.ToArray2D(), Is.EqualTo(invertByDeterminant.ToArray2D()));
                Assert.That(invertByRowReduction.ToArray2D(), Is.EqualTo(invertByDeterminant.ToArray2D()));
                Assert.That(vTransformedInverted.x, Is.EqualTo(1f));
                Assert.That(vTransformedInverted.y, Is.EqualTo(4f));
                Assert.That(vTransformedInverted.z, Is.EqualTo(7f));
            });

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.Multiple(() =>
            {
                Assert.That(vTransformedInverted.x, Is.EqualTo(1f));
                Assert.That(vTransformedInverted.y, Is.EqualTo(4f));
                Assert.That(vTransformedInverted.z, Is.EqualTo(7f));
            });
        }
    }
}