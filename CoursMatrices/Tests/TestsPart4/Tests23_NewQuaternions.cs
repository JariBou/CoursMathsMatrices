using CoursMatrices.Structs;

namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture]
    public class Tests23NewQuaternions
    {
        [Test]
        public void TestNewQuaternion()
        {
            Quaternion q = new(0f, 0.71f, 0f, 0.71f);
            Assert.Multiple(() =>
            {
                Assert.That(q.X, Is.EqualTo(0f));
                Assert.That(q.Y, Is.EqualTo(0.71f));
                Assert.That(q.Z, Is.EqualTo(0f));
                Assert.That(q.W, Is.EqualTo(0.71f));
            });
        }
        
        [Test]
        public void TestNewQuaternionFromAnother()
        {
            Quaternion q1 = new(0f, 0.71f, 0f, 0.71f);
            Quaternion q2 = q1;
            q2.X = 0.71f;

            Assert.Multiple(() =>
            {
                Assert.That(q2.X, Is.EqualTo(0.71f));
                Assert.That(q2.Y, Is.EqualTo(0.71f));
                Assert.That(q2.Z, Is.EqualTo(0f));
                Assert.That(q2.W, Is.EqualTo(0.71f));

                Assert.That(q1.X, Is.EqualTo(0f));
                Assert.That(q1.Y, Is.EqualTo(0.71f));
                Assert.That(q1.Z, Is.EqualTo(0f));
                Assert.That(q1.W, Is.EqualTo(0.71f));
            });
        }
        
        [Test]
        public void TestQuaternionIdentity()
        {
            //An identity quantity is a quaternion with no rotation
            Quaternion q = Quaternion.Identity;
            Assert.Multiple(() =>
            {
                Assert.That(q.X, Is.EqualTo(0f));
                Assert.That(q.Y, Is.EqualTo(0f));
                Assert.That(q.Z, Is.EqualTo(0f));
                Assert.That(q.W, Is.EqualTo(1f));
            });
        }
    }
}