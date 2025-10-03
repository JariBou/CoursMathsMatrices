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
            Assert.That(0.5f, Is.EqualTo(result.x));
            Assert.That(0.5f, Is.EqualTo(result.y));
            Assert.That(0.5f, Is.EqualTo(result.z));
            Assert.That(0.5f, Is.EqualTo(result.w));
            
            result = rotationYAxis * rotationXAxis;
            Assert.That(0.5f, Is.EqualTo(result.x));
            Assert.That(0.5f, Is.EqualTo(result.y));
            Assert.That(-0.5f, Is.EqualTo(result.z));
            Assert.That(0.5f, Is.EqualTo(result.w));
        }
        
        [Test]
        public void TestQuaternionMultiplyXAxisAndZAxis()
        {
            Quaternion rotationXAxis = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
            Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Quaternion result = rotationXAxis * rotationZAxis;
            Assert.That(0.5f, Is.EqualTo(result.x));
            Assert.That(-0.5f, Is.EqualTo(result.y));
            Assert.That(0.5f, Is.EqualTo(result.z));
            Assert.That(0.5f, Is.EqualTo(result.w));
            
            result = rotationZAxis * rotationXAxis;
            Assert.That(0.5f, Is.EqualTo(result.x));
            Assert.That(0.5f, Is.EqualTo(result.y));
            Assert.That(0.5f, Is.EqualTo(result.z));
            Assert.That(0.5f, Is.EqualTo(result.w));
        }
        
        [Test]
        public void TestQuaternionMultiplyYAxisAndZAxis()
        {
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
            Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Quaternion result = rotationYAxis * rotationZAxis;
            Assert.That(0.5f, Is.EqualTo(result.x));
            Assert.That(0.5f, Is.EqualTo(result.y));
            Assert.That(0.5f, Is.EqualTo(result.z));
            Assert.That(0.5f, Is.EqualTo(result.w));
            
            result = rotationZAxis * rotationYAxis;
            Assert.That(-0.5f, Is.EqualTo(result.x));
            Assert.That(0.5f, Is.EqualTo(result.y));
            Assert.That(0.5f, Is.EqualTo(result.z));
            Assert.That(0.5f, Is.EqualTo(result.w));
        }

        [Test]
        public void TestQuaternionMultiplyIdentity()
        {
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
            Quaternion qIdentity = Quaternion.Identity;

            Quaternion result = rotationYAxis * qIdentity;
            Assert.That(0f, Is.EqualTo(result.x));
            Assert.That(0.71f, Is.EqualTo(result.y));
            Assert.That(0f, Is.EqualTo(result.z));
            Assert.That(0.71f, Is.EqualTo(result.w));

            result = qIdentity * rotationYAxis;
            Assert.That(0f, Is.EqualTo(result.x));
            Assert.That(0.71f, Is.EqualTo(result.y));
            Assert.That(0f, Is.EqualTo(result.z));
            Assert.That(0.71f, Is.EqualTo(result.w));
        }
    }
}