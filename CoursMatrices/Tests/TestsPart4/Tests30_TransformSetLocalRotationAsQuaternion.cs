namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture]
    public class Tests30TransformSetLocalRotationAsQuaternion
    {
        [Test, DefaultFloatingPointTolerance(0.1d)]
        public void TestTransformSetLocalRotationQuaternionXAxis()
        {
            Transform t = new()
            {
                LocalRotationQuaternion = new Quaternion(0.259f, 0f, 0f, 0.966f)
            };

            Vector3 localRotation = t.LocalRotation;
            Assert.Multiple(() =>
            {
                Assert.That(localRotation.x, Is.EqualTo(30f));
                Assert.That(localRotation.y, Is.EqualTo(0f));
                Assert.That(localRotation.z, Is.EqualTo(0f));

                Assert.That(new[,]
                {
                    { 1f, 0f, 0f, 0f },
                    { 0f, 0.866f, -0.5f, 0f },
                    { 0f, 0.5f, 0.866f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationMatrix.ToArray2D()));
            
                Assert.That(new[,]
                {
                    { 1f, 0f, 0f, 0f },
                    { 0f, 0.866f, -0.5f, 0f },
                    { 0f, 0.5f, 0.866f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationXMatrix.ToArray2D()));

                Assert.That(new[,]
                {
                    { 1f, 0f, 0f, 0f },
                    { 0f, 1f, 0f, 0f },
                    { 0f, 0f, 1f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationYMatrix.ToArray2D()));
                
                Assert.That(new[,]
                {
                    { 1f, 0f, 0f, 0f },
                    { 0f, 1f, 0f, 0f },
                    { 0f, 0f, 1f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationZMatrix.ToArray2D()));
            });
        }
        
        [Test, DefaultFloatingPointTolerance(0.1d)]
        public void TestTransformSetLocalRotationQuaternionYAxis()
        {
            Transform t = new()
            {
                LocalRotationQuaternion = new Quaternion(0f, 0.259f, 0f, 0.966f)
            };

            Vector3 localRotation = t.LocalRotation;
            Assert.Multiple(() =>
            {
                Assert.That(localRotation.x, Is.EqualTo(0f));
                Assert.That(localRotation.y, Is.EqualTo(30f));
                Assert.That(localRotation.z, Is.EqualTo(0f));

                Assert.That(new[,]
                {
                    { 0.866f, 0f, 0.5f, 0f },
                    { 0f, 1f, 0f, 0f },
                    { -0.5f, 0f, 0.866f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationMatrix.ToArray2D()));

                Assert.That(new[,]
                {
                    { 1f, 0f, 0f, 0f },
                    { 0f, 1f, 0f, 0f },
                    { 0f, 0f, 1f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationXMatrix.ToArray2D()));
            
                Assert.That(new[,]
                {
                    { 0.866f, 0f, 0.5f, 0f },
                    { 0f, 1f, 0f, 0f },
                    { -0.5f, 0f, 0.866f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationYMatrix.ToArray2D()));

                Assert.That(new[,]
                {
                    { 1f, 0f, 0f, 0f },
                    { 0f, 1f, 0f, 0f },
                    { 0f, 0f, 1f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationZMatrix.ToArray2D()));
            });
        }
        
        [Test, DefaultFloatingPointTolerance(0.1d)]
        public void TestTransformSetLocalRotationQuaternionZAxis()
        {
            Transform t = new();
            t.LocalRotationQuaternion = new Quaternion(0f, 0f, 0.259f, 0.966f);

            Vector3 localRotation = t.LocalRotation;
            Assert.Multiple(() =>
            {
                Assert.That(localRotation.x, Is.EqualTo(0f));
                Assert.That(localRotation.y, Is.EqualTo(0f));
                Assert.That(localRotation.z, Is.EqualTo(30f));

                Assert.That(new[,]
                {
                    { 0.866f, -0.5f, 0f, 0f },
                    { 0.5f, 0.866f, 0f, 0f },
                    { 0f, 0f, 1f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationMatrix.ToArray2D()));

                Assert.That(new[,]
                {
                    { 1f, 0f, 0f, 0f },
                    { 0f, 1f, 0f, 0f },
                    { 0f, 0f, 1f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationXMatrix.ToArray2D()));
            
                Assert.That(new[,]
                {
                    { 1f, 0f, 0f, 0f },
                    { 0f, 1f, 0f, 0f },
                    { 0f, 0f, 1f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationYMatrix.ToArray2D()));

                Assert.That(new[,]
                {
                    { 0.866f, -0.5f, 0f, 0f },
                    { 0.5f, 0.866f, 0f, 0f },
                    { 0f, 0f, 1f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationZMatrix.ToArray2D()));
            });
        }
        
        [Test, DefaultFloatingPointTolerance(0.1d)]
        public void TestTransformSetLocalRotationQuaternionMultipleAxis()
        {
            Transform t = new()
            {
                LocalRotationQuaternion = new Quaternion(0.430f, 0.092f, 0.561f, 0.701f)
            };

            Vector3 localRotation = t.LocalRotation;
            Assert.Multiple(() =>
            {
                Assert.That(localRotation.x, Is.EqualTo(30f));
                Assert.That(localRotation.y, Is.EqualTo(45f));
                Assert.That(localRotation.z, Is.EqualTo(90f));

                Assert.That(new[,]
                {
                    { 0.353f, -0.707f, 0.612f, 0f },
                    { 0.866f, 0.000f, -0.500f, 0f },
                    { 0.353f, 0.707f, 0.612f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationMatrix.ToArray2D()));

                Assert.That(new[,]
                {
                    { 1f, 0f, 0f, 0f },
                    { 0f, 0.866f, -0.5f, 0f },
                    { 0f, 0.5f, 0.866f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationXMatrix.ToArray2D()));

                Assert.That(new[,]
                {
                    { 0.707f, 0f, 0.707f, 0f },
                    { 0f, 1f, 0f, 0f },
                    { -0.707f, 0f, 0.707f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationYMatrix.ToArray2D()));

                Assert.That(new[,]
                {
                    { 0f, -1f, 0f, 0f },
                    { 1f, 0f, 0f, 0f },
                    { 0f, 0f, 1f, 0f },
                    { 0f, 0f, 0f, 1f },
                }, Is.EqualTo(t.LocalRotationZMatrix.ToArray2D()));
            });
        }
    }
}