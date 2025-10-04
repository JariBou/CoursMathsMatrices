using CoursMatrices.Structs;

namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture, DefaultFloatingPointTolerance(0.01d)]
    public class Tests25QuaternionsMultiplication
    {
        [Test]
        public void TestQuaternionMultiplyXAxisAndYAxis()
        {
            Quaternion rotationXAxis = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));

            Quaternion result = rotationXAxis * rotationYAxis;
            Assert.That(0.5f, Is.EqualTo(result.X));
            Assert.That(0.5f, Is.EqualTo(result.Y));
            Assert.That(0.5f, Is.EqualTo(result.Z));
            Assert.That(0.5f, Is.EqualTo(result.W));
            
            result = rotationYAxis * rotationXAxis;
            Assert.That(0.5f, Is.EqualTo(result.X));
            Assert.That(0.5f, Is.EqualTo(result.Y));
            Assert.That(-0.5f, Is.EqualTo(result.Z));
            Assert.That(0.5f, Is.EqualTo(result.W));
        }
        
        [Test]
        public void TestQuaternionMultiplyXAxisAndZAxis()
        {
            Quaternion rotationXAxis = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
            Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Quaternion result = rotationXAxis * rotationZAxis;
            Assert.That(0.5f, Is.EqualTo(result.X));
            Assert.That(-0.5f, Is.EqualTo(result.Y));
            Assert.That(0.5f, Is.EqualTo(result.Z));
            Assert.That(0.5f, Is.EqualTo(result.W));
            
            result = rotationZAxis * rotationXAxis;
            Assert.That(0.5f, Is.EqualTo(result.X));
            Assert.That(0.5f, Is.EqualTo(result.Y));
            Assert.That(0.5f, Is.EqualTo(result.Z));
            Assert.That(0.5f, Is.EqualTo(result.W));
        }
        
        [Test]
        public void TestQuaternionMultiplyYAxisAndZAxis()
        {
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
            Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Quaternion result = rotationYAxis * rotationZAxis;
            Assert.That(0.5f, Is.EqualTo(result.X));
            Assert.That(0.5f, Is.EqualTo(result.Y));
            Assert.That(0.5f, Is.EqualTo(result.Z));
            Assert.That(0.5f, Is.EqualTo(result.W));
            
            result = rotationZAxis * rotationYAxis;
            Assert.That(-0.5f, Is.EqualTo(result.X));
            Assert.That(0.5f, Is.EqualTo(result.Y));
            Assert.That(0.5f, Is.EqualTo(result.Z));
            Assert.That(0.5f, Is.EqualTo(result.W));
        }

        [Test]
        public void TestQuaternionMultiplyIdentity()
        {
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
            Quaternion qIdentity = Quaternion.Identity;

            Quaternion result = rotationYAxis * qIdentity;
            Assert.That(0f, Is.EqualTo(result.X));
            Assert.That(0.71f, Is.EqualTo(result.Y));
            Assert.That(0f, Is.EqualTo(result.Z));
            Assert.That(0.71f, Is.EqualTo(result.W));

            result = qIdentity * rotationYAxis;
            Assert.That(0f, Is.EqualTo(result.X));
            Assert.That(0.71f, Is.EqualTo(result.Y));
            Assert.That(0f, Is.EqualTo(result.Z));
            Assert.That(0.71f, Is.EqualTo(result.W));
        }
    }
}