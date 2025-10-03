namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture, DefaultFloatingPointTolerance(0.01d)]
    public class Tests24QuaternionsAngleAxis
    {
        [Test]
        public void TestQuaternionAngleAxisX()
        {
            //90 degree around X axis
            float angle = 90f;
            Vector3 axis = new(1f, 0f, 0f);
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Assert.Multiple(() =>
            {
                Assert.That(q.x, Is.EqualTo(0.71f));
                Assert.That(q.y, Is.EqualTo(0f));
                Assert.That(q.z, Is.EqualTo(0f));
                Assert.That(q.w, Is.EqualTo(0.71f));
            });
        }

        [Test]
        public void TestQuaternionAngleAxisY()
        {
            //90 degree around Y axis
            float angle = 90f;
            Vector3 axis = new(0f, 1f, 0f);
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Assert.Multiple(() =>
            {
                Assert.That(q.x, Is.EqualTo(0f));
                Assert.That(q.y, Is.EqualTo(0.71f));
                Assert.That(q.z, Is.EqualTo(0f));
                Assert.That(q.w, Is.EqualTo(0.71f));
            });
        }

        [Test]
        public void TestQuaternionAngleAxisZ()
        {
            //90 degree around Z axis
            float angle = 90f;
            Vector3 axis = new(0f, 0f, 1f);
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Assert.Multiple(() =>
            {
                Assert.That(q.x, Is.EqualTo(0f));
                Assert.That(q.y, Is.EqualTo(0f));
                Assert.That(actual: q.z, Is.EqualTo(0.71f));
                Assert.That(q.w, Is.EqualTo(0.71f));
            });
        }

        [Test]
        public void TestQuaternionCustomAxis()
        {
            //60 degree around Vector(0,3,4)
            float angle = 60f;
            Vector3 axis = new(0f, 3f, 4f);
            Quaternion q = Quaternion.AngleAxis(angle, axis);
            Assert.Multiple(() =>
            {
                Assert.That(q.x, Is.EqualTo(0f));
                Assert.That(q.y, Is.EqualTo(0.3f));
                Assert.That(q.z, Is.EqualTo(0.4f));
                Assert.That(q.w, Is.EqualTo(0.87f));
            });
        }
    }
}