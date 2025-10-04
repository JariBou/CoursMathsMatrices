using CoursMatrices.Structs;

namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture]
    public class Tests29TransformGetLocalRotationAsQuaternion
    {
        [Test, DefaultFloatingPointTolerance(0.01d)]
        public void TestTransformGetLocalRotationQuaternionDefault()
        {
            Transform t = new();
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.Multiple(() =>
            {
                Assert.That(q.X, Is.EqualTo(0f));
                Assert.That(q.Y, Is.EqualTo(0f));
                Assert.That(q.Z, Is.EqualTo(0f));
                Assert.That(q.W, Is.EqualTo(1f));
            });
        }
        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestTransformGetLocalRotationQuaternionXAxis()
        {
            Transform t = new()
            {
                LocalRotation = new Vector3(30f, 0f, 0f)
            };

            Quaternion q = t.LocalRotationQuaternion;
            Assert.Multiple(() =>
            {
                Assert.That(q.X, Is.EqualTo(0.259f));
                Assert.That(q.Y, Is.EqualTo(0f));
                Assert.That(q.Z, Is.EqualTo(0f));
                Assert.That(q.W, Is.EqualTo(0.966f));
            });
        }
        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestTransformGetLocalRotationQuaternionYAxis()
        {
            Transform t = new()
            {
                LocalRotation = new Vector3(0f, 30f, 0f)
            };

            Quaternion q = t.LocalRotationQuaternion;
            Assert.Multiple(() =>
            {
                Assert.That(q.X, Is.EqualTo(0f));
                Assert.That(q.Y, Is.EqualTo(0.259f));
                Assert.That(q.Z, Is.EqualTo(0f));
                Assert.That(q.W, Is.EqualTo(0.966f));
            });
        }
        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestTransformGetLocalRotationQuaternionZAxis()
        {
            Transform t = new()
            {
                LocalRotation = new Vector3(0f, 0f, 30f)
            };

            Quaternion q = t.LocalRotationQuaternion;
            Assert.Multiple(() =>
            {
                Assert.That(q.X, Is.EqualTo(0f));
                Assert.That(q.Y, Is.EqualTo(0f));
                Assert.That(q.Z, Is.EqualTo(0.259f));
                Assert.That(q.W, Is.EqualTo(0.966f));
            });
        }
        
        [Test, DefaultFloatingPointTolerance(0.001d)]
        public void TestTransformGetLocalRotationQuaternionMultipleAxis()
        {
            Transform t = new()
            {
                LocalRotation = new Vector3(30f, 45f, 90f)
            };

            Quaternion q = t.LocalRotationQuaternion;
            Assert.Multiple(() =>
            {
                Assert.That(q.X, Is.EqualTo(0.430f));
                Assert.That(q.Y, Is.EqualTo(0.092f));
                Assert.That(q.Z, Is.EqualTo(0.561f));
                Assert.That(q.W, Is.EqualTo(0.701f));
            });
        }
    }
}