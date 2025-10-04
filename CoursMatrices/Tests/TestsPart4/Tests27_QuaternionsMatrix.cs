using CoursMatrices.Structs;

namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture, DefaultFloatingPointTolerance(0.01d)]
    public class Tests27QuaternionsMatrix
    {
        [Test]
        public void TestQuaternionMatrixXAxis()
        {
            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));
            
            Assert.That(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(q.Matrix.ToArray2D()));
        }
        
        [Test]
        public void TestQuaternionMatrixYAxis()
        {
            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 1f, 0f));
            
            Assert.That(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(q.Matrix.ToArray2D()));
        }
        
        [Test]
        public void TestQuaternionMatrixZAxis()
        {
            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 0f, 1f));
            
            Assert.That(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(q.Matrix.ToArray2D()));
        }
        
        [Test]
        public void TestQuaternionMatrixMultipleAxis()
        {
            Quaternion rotationXAxis = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));

            Quaternion result = rotationXAxis * rotationYAxis;
            Assert.That(new[,]
            {
                { 0f, 0f, 1f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { -0.866f, 0.5f, 0f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(result.Matrix.ToArray2D()));

            Quaternion invertedResult = rotationYAxis * rotationXAxis;
            Assert.That(new[,]
            {
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { -1f, 0f, 0f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(invertedResult.Matrix.ToArray2D()));
        }
        
        [Test]
        public void TestQuaternionMatrixIdentity()
        {
            Quaternion q = Quaternion.Identity;
            
            Assert.That(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(q.Matrix.ToArray2D()));
        }

    }
}