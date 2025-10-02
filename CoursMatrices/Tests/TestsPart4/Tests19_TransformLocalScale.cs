namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture, DefaultFloatingPointTolerance(0.001d)]
    public class Tests19TransformLocalScale
    {
        [Test]
        public void TestDefaultValues()
        {
            Transform t = new Transform();

            Assert.Multiple(() =>
            {
                //Default Scale
                Assert.That(t.LocalScale.x, Is.EqualTo(1f));
                Assert.That(t.LocalScale.y, Is.EqualTo(1f));
                Assert.That(t.LocalScale.z, Is.EqualTo(1f));

                //Default Matrix
                Assert.That(new[,]
                {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalScaleMatrix.ToArray2D()));
            });
        }

        [Test]
        public void TestChangeScale()
        {
            Transform t = new Transform();

            //Scale X
            t.LocalScale = new Vector3(2f, 1f, 1f);
            Assert.That(new[,]
            {
                { 2f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalScaleMatrix.ToArray2D()));
            
            //Scale Y
            t.LocalScale = new Vector3(1f, 5f, 1f);
            Assert.That(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 5f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalScaleMatrix.ToArray2D()));
            
            //Scale Z
            t.LocalScale = new Vector3(1f, 1f, 23f);
            Assert.That(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 23f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalScaleMatrix.ToArray2D()));
        }
    }
}