namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture, DefaultFloatingPointTolerance(0.001d)]
    public class Tests18TransformLocalRotations
    {
        [Test]
        public void TestDefaultValues()
        {
            
            Transform t = new Transform();
            
            //Default Rotation
            Assert.That(t.LocalRotation.x, Is.EqualTo(0f));
            Assert.That(t.LocalRotation.y, Is.EqualTo(0f));
            Assert.That(t.LocalRotation.z, Is.EqualTo(0f));

            //Default Matrices
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
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalRotationZMatrix.ToArray2D()));
            
            Assert.That(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalRotationMatrix.ToArray2D()));
        }
        
        [Test]
        public void TestChangeRotationXAxis()
        {
            Transform t = new Transform
            {
                LocalRotation = new Vector3(30f, 0f, 0f)
            };

            Assert.That(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalRotationXMatrix.ToArray2D()));

            float[,] array2D = t.LocalRotationMatrix.ToArray2D();
            Assert.That(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(array2D));
        }
        
        [Test]
        public void TestChangeRotationYAxis()
        {
            Transform t = new Transform
            {
                LocalRotation = new Vector3(0f, 30f, 0f)
            };

            Assert.That(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalRotationYMatrix.ToArray2D()));
            
            Assert.That(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalRotationMatrix.ToArray2D()));
        }
        
        [Test]
        public void TestChangeRotationZAxis()
        {
            Transform t = new()
            {
                LocalRotation = new Vector3(0f, 0f, 30f)
            };

            Assert.That(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalRotationZMatrix.ToArray2D()));
            
            Assert.That(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalRotationMatrix.ToArray2D()));
        }
        
        [Test]
        public void TestChangeRotationMultipleAxis()
        {
            //Rotations are performed around the Z axis, the X axis, and the Y axis, in that order.
            //Like Unity => https://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html
            //So the operation order is => RY * RX * RZ
            //Rotation to Multiple Axis
            
            Transform t = new()
            {
                //For LocalRotationMatrix attribute =>
                LocalRotation = new Vector3(30f, 45f, 90f)
            };

            Assert.That(new[,]
            {
                { 0.353f, -0.707f, 0.612f, 0f },
                { 0.866f, 0.000f, -0.500f, 0f },
                { 0.353f, 0.707f, 0.612f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalRotationMatrix.ToArray2D()));
        }
        
    }
}