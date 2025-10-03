namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture, DefaultFloatingPointTolerance(0.001d)]
    public class Tests20TransformLocalEverything
    {
        [Test]
        public void TestDefaultValues()
        {
            Transform t = new();

            //Default LocalToWorld Matrix
            Assert.That(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalToWorldMatrix.ToArray2D()));
            
            //Default WorldToLocal Matrix
            Assert.That(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.WorldToLocalMatrix.ToArray2D()));
        }

        [Test]
        public void TestChangeEverythingEverywhereAllAtOnce()
        {
            //Order is important when combining matrices together
            //You need to respect the following order : T * R * S
            // T = Translation Matrix
            // R = Rotation Matrix
            // S = Scale Matrix

            Transform t = new();
            t.LocalPosition = new Vector3(1f, 2f, 3f);
            t.LocalRotation = new Vector3(45f, 90f, 30f);
            t.LocalScale = new Vector3(2f, 4f, 6f);
            Assert.That(new[,]
            {
                { 0.707f, 2.449f, 4.243f, 1.000f },
                { 0.707f, 2.449f, -4.243f, 2.000f },
                { -1.732f, 2.000f, 0.000f, 3.000f },
                { 0.000f, 0.000f, 0.000f, 1.000f },
            }, Is.EqualTo(t.LocalToWorldMatrix.ToArray2D()));
            
            Assert.That(new[,]
            {
                { 0.177f, 0.177f, -0.433f, 0.768f },
                { 0.153f, 0.153f, 0.125f, -0.834f },
                { 0.118f, -0.118f, 0.000f, 0.118f },
                { 0.000f, 0.000f, 0.000f, 1.000f },
            }, Is.EqualTo(t.WorldToLocalMatrix.ToArray2D()));
        }
    }
}