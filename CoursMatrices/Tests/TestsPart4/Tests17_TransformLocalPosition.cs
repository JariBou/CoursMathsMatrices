namespace CoursMatrices.Tests.TestsPart4
{
    [TestFixture, DefaultFloatingPointTolerance(0.001d)]
    public class Tests17TransformLocalPosition
    {
        [Test]
        public void TestDefaultValues()
        {
            Transform t = new();
            
            Assert.Multiple(() =>
            {

                //Default Position
                Assert.That(t.LocalPosition.x, Is.EqualTo(0f));
                Assert.That(t.LocalPosition.y, Is.EqualTo(0f));
                Assert.That(t.LocalPosition.z, Is.EqualTo(0f));

                //Default Translation Matrix
                Assert.That(t.LocalTranslationMatrix.ToArray2D(), Is.EqualTo(new[,]
                {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }));
            });
        }
        
        [Test]
        public void TestTransformChangePosition()
        {
            Transform t = new()
            {
                //Translation
                LocalPosition = new Vector3(5f, 2f, 1f)
            };

            Assert.That(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 2f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            }, Is.EqualTo(t.LocalTranslationMatrix.ToArray2D()));
        }
        
    }
}