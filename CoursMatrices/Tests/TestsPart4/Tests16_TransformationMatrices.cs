using CoursMatrices.Matrices.Generic;

namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture, DefaultFloatingPointTolerance(0.001f)]
    public class Tests16TransformationMatrices
    {
        [Test]
        public void TestTranslatePoint()
        {
            Vector4 v = new Vector4(1f, 0f, 0f, 1f);
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

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
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
        //
        // [Test]
        // public void TestTranslateDirection()
        // {
        //     Vector4 v = new Vector4(1f, 0f, 0f, 0f);
        //     Matrix<float> m = new Matrix<float>(new[,]
        //     {
        //         { 1f, 0f, 0f, 5f },
        //         { 0f, 1f, 0f, 3f },
        //         { 0f, 0f, 1f, 1f },
        //         { 0f, 0f, 0f, 1f },
        //     });
        //     Vector4 vTransformed = m * v;
        //
        //     Assert.That(1f, vTransformed.x);
        //     Assert.That(0f, vTransformed.y);
        //     Assert.That(0f, vTransformed.z);
        //
        //     Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
        //     Assert.That(1f, vTransformedInverted.x);
        //     Assert.That(0f, vTransformedInverted.y);
        //     Assert.That(0f, vTransformedInverted.z);
        //
        //     vTransformedInverted = m.InvertByDeterminant() * vTransformed;
        //     Assert.That(1f, vTransformedInverted.x);
        //     Assert.That(0f, vTransformedInverted.y);
        //     Assert.That(0f, vTransformedInverted.z);
        // }
        //
        // [Test]
        // public void TestScalePoint()
        // {
        //     Vector4 v = new Vector4(2f, 1f, 3f, 1f);
        //     Matrix<float> m = new Matrix<float>(new[,]
        //     {
        //         { 0.5f, 0f, 0f, 0f },
        //         { 0.0f, 2f, 0f, 0f },
        //         { 0.0f, 0f, 3f, 0f },
        //         { 0.0f, 0f, 0f, 1f },
        //     });
        //
        //     Vector4 vTransformed = m * v;
        //     Assert.That(1f, vTransformed.x);
        //     Assert.That(2f, vTransformed.y);
        //     Assert.That(9f, vTransformed.z);
        //
        //     Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
        //     Assert.That(2f, vTransformedInverted.x);
        //     Assert.That(1f, vTransformedInverted.y);
        //     Assert.That(3f, vTransformedInverted.z);
        //
        //     vTransformedInverted = m.InvertByDeterminant() * vTransformed;
        //     Assert.That(2f, vTransformedInverted.x);
        //     Assert.That(1f, vTransformedInverted.y);
        //     Assert.That(3f, vTransformedInverted.z);
        // }
        //
        // [Test]
        // public void TestRotatePoint()
        // {
        //     Vector4 v = new Vector4(1f, 4f, 7f, 1f);
        //     double a = Math.PI / 2d;
        //     float cosA = (float)Math.Cos(a);
        //     float sinA = (float)Math.Sin(a);
        //     Matrix<float> m = new Matrix<float>(new[,]
        //     {
        //         { cosA, -sinA, 0f, 0f },
        //         { sinA, cosA, 0f, 0f },
        //         { 0f, 0f, 1f, 0f },
        //         { 0f, 0f, 0f, 1f },
        //     });
        //
        //     Vector4 vTransformed = m * v;
        //     Assert.That(-4f, vTransformed.x);
        //     Assert.That(1f, vTransformed.y);
        //     Assert.That(7f, vTransformed.z);
        //
        //     Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
        //     Assert.That(1f, vTransformedInverted.x);
        //     Assert.That(4f, vTransformedInverted.y);
        //     Assert.That(7f, vTransformedInverted.z);
        //
        //     vTransformedInverted = m.InvertByDeterminant() * vTransformed;
        //     Assert.That(1f, vTransformedInverted.x);
        //     Assert.That(4f, vTransformedInverted.y);
        //     Assert.That(7f, vTransformedInverted.z);
        // }
    }
}