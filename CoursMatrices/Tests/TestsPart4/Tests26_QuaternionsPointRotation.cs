namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture, DefaultFloatingPointTolerance(0.01d)]
    public class Tests26QuaternionsPointRotation
    {
        [Test]
        public void TestQuaternionPointRotation1()
        {
            Vector3 point = new(1f, 0f, 0f);
            Quaternion rotateZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Vector3 rotatedPoint = rotateZAxis * point;
            Assert.Multiple(() =>
            {
                Assert.That(rotatedPoint.x, Is.EqualTo(0f));
                Assert.That(rotatedPoint.y, Is.EqualTo(1f));
                Assert.That(rotatedPoint.z, Is.EqualTo(0f));
            });
        }
        
        [Test]
        public void TestQuaternionPointRotation2()
        {
            Vector3 point = new(0f, 2f, 1f);
            Quaternion rotateXAxis = Quaternion.AngleAxis(45f, new Vector3(1f, 0f, 0f));

            Vector3 rotatedPoint = rotateXAxis * point;
            Assert.Multiple(() =>
            {
                Assert.That(rotatedPoint.x, Is.EqualTo(0f));
                Assert.That(rotatedPoint.y, Is.EqualTo(0.71f));
                Assert.That(rotatedPoint.z, Is.EqualTo(2.12f));
            });
        }
    }
}