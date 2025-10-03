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
                Assert.That(q.x, Is.EqualTo(0f));
                Assert.That(q.y, Is.EqualTo(0.71f));
                Assert.That(q.z, Is.EqualTo(0f));
                Assert.That(q.w, Is.EqualTo(0.71f));
            });
        }
        
        [Test]
        public void TestNewQuaternionFromAnother()
        {
            Quaternion q1 = new(0f, 0.71f, 0f, 0.71f);
            Quaternion q2 = q1;
            q2.x = 0.71f;

            Assert.Multiple(() =>
            {
                Assert.That(q2.x, Is.EqualTo(0.71f));
                Assert.That(q2.y, Is.EqualTo(0.71f));
                Assert.That(q2.z, Is.EqualTo(0f));
                Assert.That(q2.w, Is.EqualTo(0.71f));

                Assert.That(q1.x, Is.EqualTo(0f));
                Assert.That(q1.y, Is.EqualTo(0.71f));
                Assert.That(q1.z, Is.EqualTo(0f));
                Assert.That(q1.w, Is.EqualTo(0.71f));
            });
        }
        
        [Test]
        public void TestQuaternionIdentity()
        {
            //An identity quantity is a quaternion with no rotation
            Quaternion q = Quaternion.Identity;
            Assert.Multiple(() =>
            {
                Assert.That(q.x, Is.EqualTo(0f));
                Assert.That(q.y, Is.EqualTo(0f));
                Assert.That(q.z, Is.EqualTo(0f));
                Assert.That(q.w, Is.EqualTo(1f));
            });
        }
    }
}